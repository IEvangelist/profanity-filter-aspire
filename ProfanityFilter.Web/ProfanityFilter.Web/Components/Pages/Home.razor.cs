namespace ProfanityFilter.Web.Components.Pages;

public sealed partial class Home : IAsyncDisposable
{
    private readonly SystemTimer _debounceTimer = new()
    {
        Interval = 500,
        AutoReset = false
    };

    private readonly IObservable<ProfanityFilterRequest>? _liveRequests;

    private HubConnection? _hub;
    private List<StrategyResponse> _strategies = [];
    private int _selectedStrategy = 0;
    private string? _text = "Content to filter...";

    [Inject]
    public required HubUriFactory HubUriFactory { get; set; }

    [Inject]
    public required ILogger<Home> Logger { get; set; }

    public Home()
    {
        _liveRequests = Observable.FromEventPattern<ElapsedEventHandler, ElapsedEventArgs>(
                handler => _debounceTimer.Elapsed += handler,
                handler => _debounceTimer.Elapsed -= handler
            )
            .Select(args => new ProfanityFilterRequest
            {
                Text = _text,
                Strategy = _selectedStrategy,
                Target = 0
            });
    }

    protected override async Task OnInitializedAsync()
    {
        _strategies = await Client.Profanity.Strategies.GetAsync() ?? [];

        if (_hub is null)
        {
            var uri = HubUriFactory.Create("profanity-filter");

            _hub = new HubConnectionBuilder()
                .WithUrl(uri)
                .WithAutomaticReconnect()
                .WithStatefulReconnect()
                .Build();

            await _hub.StartAsync();

            _ = StartLiveUpdateStreamAsync();
        }
    }

    [MemberNotNullWhen(false, nameof(_hub))]
    private bool IsHubNotConnected()
    {
        if (_hub is null or not { State: HubConnectionState.Connected })
        {
            Logger.LogWarning("""
                Not connected to the profanity filter hub.
                """);

            return true;
        }

        return false;
    }

    private async Task StartLiveUpdateStreamAsync()
    {
        if (IsHubNotConnected() || _liveRequests is null)
        {
            return;
        }

        while (true)
        {
            // Producer requests...
            var liveRequests = _liveRequests.ToAsyncEnumerable();

            // Consumer responses...
            await foreach (var response in _hub.StreamAsync<ProfanityFilterResponse>(
                "live", liveRequests))
            {
                if (response is null)
                {
                    break;
                }

                if (response is { FilteredText.Length: > 0 })
                {
                    _text = response.FilteredText;
                }

                await InvokeAsync(StateHasChanged);
            }
        }
    }

    private void OnTextChanged(ChangeEventArgs args)
    {
        _text = args?.Value?.ToString();

        _debounceTimer.Stop();
        _debounceTimer.Start();
    }

    public async ValueTask DisposeAsync()
    {
        _debounceTimer.Stop();
        _debounceTimer.Dispose();

        if (_hub is not null)
        {
            await _hub.StopAsync();
            await _hub.DisposeAsync();
        }
    }
}

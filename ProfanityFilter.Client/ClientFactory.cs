using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace ProfanityFilter.Client;

public static class ClientFactory
{
    public static ProfanityFilterClient Create(string? baseAddress)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(baseAddress);

        var authProvider = new AnonymousAuthenticationProvider();
        var adapter = new HttpClientRequestAdapter(authProvider, httpClient: new()
        {
            BaseAddress = new(baseAddress)
        });

        return new ProfanityFilterClient(adapter);
    }
}

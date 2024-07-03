namespace ProfanityFilter.Web;

public sealed class HubUriFactory(IConfiguration config)
{
    public Uri Create(string name)
    {
        var uriStr = config.GetUri(name);

        var uri = new UriBuilder(uriStr)
        {
            Path = "/profanity/hub"
        };

        return uri.Uri;
    }
}

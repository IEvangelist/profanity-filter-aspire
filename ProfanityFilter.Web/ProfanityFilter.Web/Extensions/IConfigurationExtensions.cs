namespace ProfanityFilter.Web.Extensions;

internal static class IConfigurationExtensions
{
    public static Uri GetUri(this IConfiguration configuration, string name)
    {
        var uriString = configuration.GetConnectionString(name)
            ?? configuration[name];

        ArgumentException.ThrowIfNullOrWhiteSpace(uriString);

        return new Uri(uriString);
    }
}

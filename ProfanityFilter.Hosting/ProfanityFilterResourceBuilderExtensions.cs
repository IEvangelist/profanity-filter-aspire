using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting;

public static class ProfanityFilterResourceBuilderExtensions
{
    public static IResourceBuilder<ProfanityFilterResource> AddProfanityFilter(
        this IDistributedApplicationBuilder builder,
        string name,
        string? tag = null)
    {
        var resource = new ProfanityFilterResource(name);

        var password = builder.AddParameter(
            "profanityFilterCertificatePassword");

        var source = Path.GetFullPath(
            path: ".aspnet/https/",
            basePath: Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

        var profanityFilter = builder.AddResource(resource)
            .WithImage(ProfanityFilterContainerImageTags.Image)
            .WithImageRegistry(ProfanityFilterContainerImageTags.Registry)
            .WithImageTag(tag ?? ProfanityFilterContainerImageTags.Tag)
            .WithBindMount(source, ProfanityFilterContainerImageTags.CertificateBindMountTarget)
            .WithEnvironment("ASPNETCORE_Kestrel__Certificates__Default__Password", password)
            .WithEnvironment("ASPNETCORE_Kestrel__Certificates__Default__Path", "/etc/ssl/aspnetcert/aspnetapp.pfx")
            .WithHttpsEndpoint(targetPort: 8081, env: "ASPNETCORE_HTTPS_PORTS");

        return profanityFilter;
    }
}

internal static class ProfanityFilterContainerImageTags
{
    internal const string Registry = "ghcr.io";

    internal const string Image = "ievangelist/profanity-filter-api";

    internal const string Tag = "0.1";

    internal const string CertificateBindMountTarget = "/etc/ssl/aspnetcert/";
}

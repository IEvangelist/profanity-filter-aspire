namespace Aspire.Hosting.ApplicationModel;

public sealed class ProfanityFilterResource(string name) :
    ContainerResource(name),
    IResourceWithConnectionString
{
    private EndpointReference? _httpsReference;

    public EndpointReference HttpsEndpoint =>
        _httpsReference ??= new(this, "https");

    ReferenceExpression IResourceWithConnectionString.ConnectionStringExpression =>
        ReferenceExpression.Create(
                $"https://{HttpsEndpoint.Property(EndpointProperty.Host)}:{HttpsEndpoint.Property(EndpointProperty.Port)}"
            );
}

var builder = DistributedApplication.CreateBuilder(args);

//var profanityFilter = builder.AddProfanityFilter("profanity-filter");

var name = "profanity-filter";

var resource = new ProfanityFilterResource(name);

var password = builder.AddParameter(
    "profanityFilterCertificatePassword");

var source = Path.GetFullPath(
    path: ".aspnet/https/",
    basePath: Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

var profanityFilter = builder.AddResource(resource)
    .WithImage("profanityfilter-webapi")
    .WithBindMount(source, "/etc/ssl/aspnetcert/")
    .WithEnvironment("ASPNETCORE_Kestrel__Certificates__Default__Password", password)
    .WithEnvironment("ASPNETCORE_Kestrel__Certificates__Default__Path", "/etc/ssl/aspnetcert/aspnetapp.pfx")
    .WithHttpEndpoint(targetPort: 7778)
    .WithHttpsEndpoint(targetPort: 8081, env: "ASPNETCORE_HTTPS_PORTS");

builder.AddProject<Projects.ProfanityFilter_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(profanityFilter);

builder.Build().Run();

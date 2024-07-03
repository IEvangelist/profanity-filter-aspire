var builder = DistributedApplication.CreateBuilder(args);

var profanityFilter = builder.AddProfanityFilter("profanity-filter");

builder.AddProject<Projects.ProfanityFilter_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(profanityFilter);

builder.Build().Run();

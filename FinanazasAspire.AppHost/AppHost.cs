var builder = DistributedApplication.CreateBuilder(args);
var api = builder.AddProject<Projects.Finanzas>("api");

builder.AddNpmApp(
    "frontend",
    "../finanzas.client",
    "start"
    )
    .WithReference(api)
    .WithHttpEndpoint(targetPort: 4200, name: "frontend")
    .WithExternalHttpEndpoints();
builder.Build().Run();

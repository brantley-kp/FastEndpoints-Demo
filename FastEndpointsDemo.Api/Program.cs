using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsDemo.Application.Commands;
using FastEndpointsDemo.Application.Interfaces;
using FastEndpointsDemo.Infrastructure.Repositories;

var bld = WebApplication.CreateBuilder();

// FastEndpoints
bld.Services.AddFastEndpoints(o => o.Assemblies =
    [
        typeof(Program).Assembly,
    ]).SwaggerDocument();

// Controllers
bld.Services.AddControllers();

// MediatR
bld.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetCatCommand>());

// Infrastructure (repositories)
bld.Services.AddSingleton<ICatRepository, CatRepository>();
bld.Services.AddSingleton<IDogRepository, DogRepository>();

var app = bld.Build();

// Minimal API health check example
app.MapGet("/health", () => new { status = "All pets are healthy!" });

// FastEndpoints
app.UseFastEndpoints().UseSwaggerGen();

// Controllers
app.MapControllers();

app.Run();

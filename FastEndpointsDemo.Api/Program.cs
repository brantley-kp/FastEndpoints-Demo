using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsDemo.Application.Commands;
using FastEndpointsDemo.Application.Interfaces;
using FastEndpointsDemo.Infrastructure.Repositories;

var bld = WebApplication.CreateBuilder();

bld.Services.AddFastEndpoints(o => o.Assemblies =
    [
        typeof(Program).Assembly,
    ]).SwaggerDocument();

bld.Services.AddControllers();

bld.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetCatCommand>());

bld.Services.AddSingleton<ICatRepository, CatRepository>();
bld.Services.AddSingleton<IDogRepository, DogRepository>();

var app = bld.Build();

app.MapGet("/health", () => new { status = "All pets are healthy!" });

app.UseFastEndpoints().UseSwaggerGen();
app.Run();

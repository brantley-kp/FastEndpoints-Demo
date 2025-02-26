using FastEndpoints;
using FastEndpointsDemo.Application.Interfaces;
using FastEndpointsDemo.Infrastructure.Repositories;

var bld = WebApplication.CreateBuilder();

bld.Services.AddFastEndpoints();
bld.Services.AddControllers();

bld.Services.AddSingleton<ICatRepository, CatRepository>();
bld.Services.AddSingleton<IDogRepository, DogRepository>();

var app = bld.Build();
app.UseFastEndpoints();
app.Run();

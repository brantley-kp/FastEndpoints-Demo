using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsDemo.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FastEndpointsDemo.Api.Endpoints.Dogs;

public class Get(ISender sender) : Endpoint<GetRequest, Results<Ok<GetResponse>,
                                                                NotFound>>
{
    public override void Configure()
    {
        Get("/endpoints/dogs/{id}");
        AllowAnonymous();
        Description(x => x.AutoTagOverride("Dogs Endpoints"));
    }

    public override async Task<Results<Ok<GetResponse>, NotFound>> ExecuteAsync(GetRequest req, CancellationToken _)
    {
        var command = new GetDogCommand(req.Id);

        var dog = await sender.Send(command);

        if (dog is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(new GetResponse()
        {
            Id = dog.Id,
            Name = dog.Name,
            IsGood = dog.IsGood
        });
    }
}

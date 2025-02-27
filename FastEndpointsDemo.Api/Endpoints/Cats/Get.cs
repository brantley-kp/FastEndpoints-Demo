using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsDemo.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FastEndpointsDemo.Api.Endpoints.Cats;

public class Get(ISender sender) : Endpoint<GetRequest, Results<Ok<GetResponse>,
                                                                NotFound>>
{
    public override void Configure()
    {
        Get("/endpoints/cats/{id}");
        AllowAnonymous();
        Description(x => x.AutoTagOverride("Cats Endpoints"));
    }

    public override async Task<Results<Ok<GetResponse>, NotFound>> ExecuteAsync(GetRequest req, CancellationToken _)
    {
        var command = new GetCatCommand(req.Id);

        var cat = await sender.Send(command);

        if (cat is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(new GetResponse()
        {
            Id = cat.Id,
            Name = cat.Name,
            IsGood = cat.IsGood
        });
    }
}

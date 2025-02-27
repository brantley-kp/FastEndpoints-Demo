using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsDemo.Application.Commands;
using MediatR;

namespace FastEndpointsDemo.Api.Endpoints.Cats;

public class Add(ISender sender) : Endpoint<AddRequest, AddResponse>
{
    public override void Configure()
    {
        Post("/endpoints/cats/add");
        AllowAnonymous();
        Description(x => x.AutoTagOverride("Cats Endpoints"));
    }

    public override async Task HandleAsync(AddRequest req, CancellationToken _)
    {
        var command = new AddCatCommand(req.Name, req.IsGood);

        var id = await sender.Send(command);

        // FastEndpoint's MediatR Send() alternative
        // var id = await command.ExecuteAsync();

        await SendAsync(new() { Id = id }, statusCode: 200);
    }
}

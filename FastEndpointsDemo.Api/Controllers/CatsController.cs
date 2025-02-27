using FastEndpointsDemo.Api.Controllers.Models;
using FastEndpointsDemo.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastEndpointsDemo.Api.Controllers;

[Route("controllers/cats")]
[ApiController]
public class CatsController(ISender sender) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddCat(AddCatRequest req)
    {
        if (req.Name.Equals("string", StringComparison.OrdinalIgnoreCase))
        {
            return new BadRequestObjectResult("Who names their cat \"string\"??");
        }

        if (req.Name.Equals("fluffy", StringComparison.OrdinalIgnoreCase))
        {
            return new BadRequestObjectResult("Name is too generic!");
        }

        var command = new AddCatCommand(req.Name, req.IsGood);

        var id = await sender.Send(command);

        return new OkObjectResult(new AddCatResponse { Id = id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCat(Guid id)
    {
        var command = new GetCatCommand(id);

        var cat = await sender.Send(command);

        if (cat is null)
        {
            return new NotFoundResult();
        }

        return new OkObjectResult(new GetCatResponse()
        {
            Id = cat.Id,
            Name = cat.Name,
            IsGood = cat.IsGood
        });
    }
}

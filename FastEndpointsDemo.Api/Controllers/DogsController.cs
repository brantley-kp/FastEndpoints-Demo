using FastEndpointsDemo.Api.Controllers.Models;
using FastEndpointsDemo.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastEndpointsDemo.Api.Controllers;

[Route("controllers/dogs")]
[ApiController]
public class DogsController(ISender sender) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddDog(AddDogRequest req)
    {
        if (!IsValidName(req.Name))
        {
            return new BadRequestObjectResult("Name is too generic!");
        }

        var command = new AddDogCommand(req.Name);

        var id = await sender.Send(command);

        return new OkObjectResult(new AddDogResponse { Id = id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetDog(Guid id)
    {
        var command = new GetDogCommand(id);

        var dog = await sender.Send(command);

        if (dog is null)
        {
            return new NotFoundResult();
        }

        return new OkObjectResult(new GetDogResponse()
        {
            Id = dog.Id,
            Name = dog.Name,
            IsGood = dog.IsGood
        });
    }

    private static bool IsValidName(string name) =>
        !name.Equals("string", StringComparison.OrdinalIgnoreCase) &&
        !name.Equals("fluffy", StringComparison.OrdinalIgnoreCase);
}
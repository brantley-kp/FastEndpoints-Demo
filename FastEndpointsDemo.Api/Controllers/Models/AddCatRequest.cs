using System.ComponentModel.DataAnnotations;

namespace FastEndpointsDemo.Api.Controllers.Models;

public class AddCatRequest
{
    [MinLength(2)]
    public required string Name { get; set; }

    public required bool IsGood { get; set; }
}

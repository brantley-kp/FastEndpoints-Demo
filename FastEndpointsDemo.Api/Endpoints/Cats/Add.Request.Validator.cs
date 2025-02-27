using FastEndpoints;
using FluentValidation;

namespace FastEndpointsDemo.Api.Endpoints.Cats;

public class AddRequestValidator : Validator<AddRequest>
{
    public AddRequestValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(2)
            .WithMessage("Name is too short!")
            .Must(n => !n.Equals("string", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Who names their cat \"string\"??")
            .Must(n => !n.Equals("fluffy", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Name is too generic!");
    }
}

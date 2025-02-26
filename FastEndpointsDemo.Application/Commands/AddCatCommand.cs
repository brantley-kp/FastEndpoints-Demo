using FastEndpoints;
using FastEndpointsDemo.Application.Interfaces;
using FastEndpointsDemo.Domain.Aggregates;
using MediatR;

namespace FastEndpointsDemo.Application.Commands;

/// <remarks>
/// Demonstration of FastEndpoints out-of-the-box MediatR replacement
/// </remarks>
public readonly record struct AddCatCommand(string Name, bool IsGood) :
    IRequest, // MediatR
    ICommand; // FastEndpoints

public class AddCatCommandHandler(ICatRepository catRepository) :
    IRequestHandler<AddCatCommand>, // MediatR
    ICommandHandler<AddCatCommand> // FastEndpoints
{
    /// <remarks>
    /// MediatR implementation
    /// </remarks>
    public async Task Handle(AddCatCommand request, CancellationToken cancellationToken)
    {
        var cat = new Cat(Guid.NewGuid(), request.Name, request.IsGood);
        await catRepository.Add(cat);
    }

    /// <remarks>
    /// FastEndpoints implementation
    /// </remarks>
    public async Task ExecuteAsync(AddCatCommand command, CancellationToken ct)
    {
        var cat = new Cat(Guid.NewGuid(), command.Name, command.IsGood);
        await catRepository.Add(cat);
    }
}
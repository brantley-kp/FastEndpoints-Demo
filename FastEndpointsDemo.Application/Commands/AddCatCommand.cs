using FastEndpoints;
using FastEndpointsDemo.Application.Interfaces;
using FastEndpointsDemo.Domain.Aggregates;
using MediatR;

namespace FastEndpointsDemo.Application.Commands;

/// <remarks>
/// Demonstration of FastEndpoints out-of-the-box MediatR replacement
/// </remarks>
public readonly record struct AddCatCommand(string Name, bool IsGood) :
    IRequest<Guid>, // MediatR
    ICommand<Guid>; // FastEndpoints

public class AddCatCommandHandler(ICatRepository catRepository) :
    IRequestHandler<AddCatCommand, Guid>, // MediatR
    ICommandHandler<AddCatCommand, Guid> // FastEndpoints
{
    /// <remarks>
    /// MediatR implementation
    /// </remarks>
    public async Task<Guid> Handle(AddCatCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();

        var cat = new Cat(id, request.Name, request.IsGood);

        await catRepository.Add(cat);

        return id;
    }

    /// <remarks>
    /// FastEndpoints implementation
    /// </remarks>
    public async Task<Guid> ExecuteAsync(AddCatCommand command, CancellationToken ct)
    {
        var id = Guid.NewGuid();

        var cat = new Cat(id, command.Name, command.IsGood);

        await catRepository.Add(cat);

        return id;
    }
}
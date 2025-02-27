using FastEndpointsDemo.Application.Interfaces;
using FastEndpointsDemo.Domain.Aggregates;
using MediatR;

namespace FastEndpointsDemo.Application.Commands;

public readonly record struct AddDogCommand(string Name) : IRequest<Guid>;

public class AddDogCommandHandler(IDogRepository dogRepository) : IRequestHandler<AddDogCommand, Guid>
{
    public async Task<Guid> Handle(AddDogCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        var dog = new Dog(id, request.Name);
        await dogRepository.Add(dog);
        return id;
    }
}
using FastEndpointsDemo.Application.Interfaces;
using FastEndpointsDemo.Domain.Aggregates;
using MediatR;

namespace FastEndpointsDemo.Application.Commands;

public readonly record struct AddDogCommand(string Name) : IRequest;

public class AddDogCommandHandler(IDogRepository dogRepository) : IRequestHandler<AddDogCommand>
{
    public async Task Handle(AddDogCommand request, CancellationToken cancellationToken)
    {
        var dog = new Dog(Guid.NewGuid(), request.Name);
        await dogRepository.Add(dog);
    }
}
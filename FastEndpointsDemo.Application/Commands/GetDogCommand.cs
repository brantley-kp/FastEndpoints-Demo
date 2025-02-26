using FastEndpointsDemo.Application.Interfaces;
using FastEndpointsDemo.Domain.Aggregates;
using MediatR;

namespace FastEndpointsDemo.Application.Commands;

public readonly record struct GetDogCommand(Guid Id) : IRequest<Dog>;

public class GetDogCommandHandler(IDogRepository dogRepository) : IRequestHandler<GetDogCommand, Dog>
{
    public async Task<Dog> Handle(GetDogCommand request, CancellationToken cancellationToken)
    {
        return await dogRepository.Get(request.Id);
    }
}

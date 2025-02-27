using FastEndpointsDemo.Application.Interfaces;
using FastEndpointsDemo.Domain.Aggregates;
using MediatR;

namespace FastEndpointsDemo.Application.Commands;

public readonly record struct GetCatCommand(Guid Id) : IRequest<Cat?>;

public class GetCatCommandHandler(ICatRepository catRepository) : IRequestHandler<GetCatCommand, Cat?>
{
    public async Task<Cat?> Handle(GetCatCommand request, CancellationToken cancellationToken)
    {
        return await catRepository.Get(request.Id);
    }
}

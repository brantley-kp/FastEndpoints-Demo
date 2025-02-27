using FastEndpointsDemo.Domain.Aggregates;

namespace FastEndpointsDemo.Application.Interfaces;

public interface ICatRepository
{
    public Task Add(Cat cat);

    public Task<Cat?> Get(Guid id);
}

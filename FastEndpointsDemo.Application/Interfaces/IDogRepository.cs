using FastEndpointsDemo.Domain.Aggregates;

namespace FastEndpointsDemo.Application.Interfaces;

public interface IDogRepository
{
    public Task Add(Dog dog);

    public Task<Dog> Get(Guid id);
}

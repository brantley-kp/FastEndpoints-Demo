using System.Collections.Concurrent;
using FastEndpointsDemo.Application.Interfaces;
using FastEndpointsDemo.Domain.Aggregates;

namespace FastEndpointsDemo.Infrastructure.Repositories;

public class DogRepository : IDogRepository
{
    private static readonly ConcurrentDictionary<Guid, Dog> _mockStore = new();

    public Task Add(Dog dog)
    {
        _mockStore[dog.Id] = dog;
        return Task.CompletedTask;
    }

    public Task<Dog?> Get(Guid id)
    {
        if (!_mockStore.ContainsKey(id))
        {
            return Task.FromResult<Dog?>(null);
        }

        return Task.FromResult<Dog?>(_mockStore[id]);
    }
}

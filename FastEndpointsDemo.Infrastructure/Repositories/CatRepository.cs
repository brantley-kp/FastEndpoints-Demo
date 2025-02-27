using System.Collections.Concurrent;
using FastEndpointsDemo.Application.Interfaces;
using FastEndpointsDemo.Domain.Aggregates;

namespace FastEndpointsDemo.Infrastructure.Repositories;

public class CatRepository : ICatRepository
{
    private static readonly ConcurrentDictionary<Guid, Cat> _mockStore = new();

    public Task Add(Cat cat)
    {
        _mockStore[cat.Id] = cat;
        return Task.CompletedTask;
    }

    public Task<Cat?> Get(Guid id)
    {
        if (!_mockStore.ContainsKey(id))
        {
            return Task.FromResult<Cat?>(null);
        }

        return Task.FromResult<Cat?>(_mockStore[id]);
    }
}

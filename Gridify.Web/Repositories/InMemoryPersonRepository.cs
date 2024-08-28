namespace Gridify.Web.Repositories;

using System.Collections.Concurrent;
using Gridify.Web.Models;

internal sealed class InMemoryPersonRepository : IPersonRepository
{
    private static readonly ConcurrentDictionary<Guid, Person> Db = new();

    public Task<Person> Create(CreatePerson person)
    {
        Person p = new()
        {
            Id = Guid.NewGuid(),
            FirstName = person.FirstName,
            LastName = person.LastName,
            Birthday = person.Birthday
        };

        if (!Db.TryAdd(p.Id, p))
        {
            throw new Exception("Failed to add Person to database");
        }

        return Task.FromResult(p);
    }

    public Task<IQueryable<Person>> Get()
    {
        var allPeople = Db.Select(x => x.Value);

        return Task.FromResult(allPeople.AsQueryable());
    }
}
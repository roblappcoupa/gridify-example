namespace Gridify.Web.Services;

using Gridify.Web.Models;
using Gridify.Web.Repositories;

internal sealed class PersonService : IPersonService
{
    private readonly IPersonRepository repository;

    public PersonService(IPersonRepository repository)
    {
        this.repository = repository;
    }

    public Task<Person> Create(CreatePerson person) => this.repository.Create(person);

    public async Task<Paging<Person>> Get(GridifyQuery gridifyQuery)
    {
        var allPeople = await this.repository.Get();
        
        // Perform filtering, sorting and paging
        // There are many extension methods which can be found here: https://alirezanet.github.io/Gridify/guide/extensions
        var result = allPeople.Gridify(gridifyQuery);

        return result;
    }
}
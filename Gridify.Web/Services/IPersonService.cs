namespace Gridify.Web.Services;

using Gridify.Web.Models;

public interface IPersonService
{
    Task<Person> Create(CreatePerson person);

    Task<Paging<Person>> Get(GridifyQuery gridifyQuery);
}
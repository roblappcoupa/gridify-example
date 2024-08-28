namespace Gridify.Web.Repositories;

using Gridify.Web.Models;

public interface IPersonRepository
{
    Task<Person> Create(CreatePerson person);
    
    Task<IQueryable<Person>> Get();
}
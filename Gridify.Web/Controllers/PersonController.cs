namespace Gridify.Web.Controllers;

using Gridify.Web.Models;
using Gridify.Web.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class PersonController : ControllerBase
{
    private readonly IPersonService personService;

    public PersonController(IPersonService personService)
    {
        this.personService = personService;
    }

    [HttpPost]
    public Task<Person> Create(CreatePerson person) => this.personService.Create(person);
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]GridifyQuery gridifyQuery)
    {
        var result = await this.personService.Get(gridifyQuery);

        return this.Ok(result);
    }
}
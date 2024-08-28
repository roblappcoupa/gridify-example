namespace Gridify.Web.Models;

public abstract class PersonBase
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateTime Birthday { get; set; }

    public TimeSpan Age => DateTime.UtcNow - this.Birthday;
}
using EventsApp.Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace EventsApp.Domain.Models;

public class User: IdentityUser<int>
{
    public string Gender { get; set; }
    public ICollection<Event>? CreatedEvents { get; set; }
    public ICollection<UserEvent>? UserEvents { get; set; }

    public User()
    {
        Gender = Constants.Gender_None;
    }
}

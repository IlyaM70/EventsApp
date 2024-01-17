using System.ComponentModel.DataAnnotations;
using EventsApp.Domain.Models;
using EventsApp.Domain.Services;

namespace EventsApp.WebMVC.Models;

public class EventViewModel
{
    public int Id { get; set; }

    [Required(),MaxLength(50)]
    public string Name { get; set; }

    [Required, MaxLength(200)]
    public string Description { get; set; }
    public User? Creater { get; set; }
    public int CreaterId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }

    [Required]
    public DateTime Begining { get; set; }

    [Required]
    public DateTime Ending { get; set; }

    [Required]
    public DateTime ApplicationsDue { get; set; }
    public bool IsCommercial { get; set; }

    [Required, MaxLength(200)]
    public string Address { get; set; }
    public int MinPersons { get; set; }
    public int MaxPersons { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public string GenderRestrictions { get; set; }
    public int? MainEventId { get; set; }
    public Event? MainEvent { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public ICollection<Event>? SubEvents { get; set; }
    public IList<UserEvent>? UserEvents { get; set; }

    public EventViewModel()
    {
        GenderRestrictions = Constants.Gender_None;
        Name = "";
        Address = "";
        Description = "";
        MinPersons = 1;
        MaxPersons = 2;
        MinAge = 0;
        MaxAge = 120;
        Begining = DateTime.Now;
        Ending = DateTime.Now.AddHours(2);
        ApplicationsDue = DateTime.Now.AddHours(1);
        Created = DateTime.UtcNow;
        Updated = DateTime.UtcNow;
        MainEventId = null;
        CategoryId = null;
    }
}

using EventsApp.Domain.Services;

namespace EventsApp.Domain.Models;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public User? Creater { get; set; }
    public int CreaterId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public DateTime Begining { get; set; }
    public DateTime Ending { get; set; }
    public DateTime ApplicationsDue { get; set; }
    public bool IsCommercial { get; set; }
    public string Address { get; set; }
    public int MinPersons { get; set; }
    public int MaxPersons { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public string GenderRestrictions{ get; set; }
    public int? MainEventId { get; set; }
    public Event? MainEvent { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public ICollection<Event>? SubEvents { get; set; }
    public IList<UserEvent>? UserEvents { get; set; }

    public Event()
    {
        GenderRestrictions = Constants.Gender_None;
        Name = "";
        Address = "";
        Description = "";
    }

}

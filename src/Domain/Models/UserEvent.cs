namespace EventsApp.Domain.Models;

/// <summary>
/// Entity for many to many connection between users and events
/// </summary>
public class UserEvent
{
    public int UserId { get; set; }
    public int EventId { get; set; }

    public User? User { get; set; }
    public Event? Event { get; set; }
}

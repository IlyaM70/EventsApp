using EventsApp.Domain.Services;
using MediatR;

namespace EventsApp.Application.Events.Commands.UpdateEvent;

public record UpdateEventCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string Description { get; init; } = "";
    public DateTime Updated { get; init; }
    public DateTime Begining { get; init; }
    public DateTime Ending { get; init; }
    public DateTime ApplicationsDue { get; init; }
    public bool IsCommercial { get; init; }
    public string Address { get; init; } = "";
    public int MinPersons { get; init; }
    public int MaxPersons { get; init; }
    public int MinAge { get; init; }
    public int MaxAge { get; init; }
    public string GenderRestrictions { get; init; } = Constants.Gender_None;
    public int? MainEventId { get; init; }
    public int? CategoryId { get; init; }
}

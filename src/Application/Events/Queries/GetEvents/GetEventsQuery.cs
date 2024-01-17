using EventsApp.Application.Interfaces;
using EventsApp.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventsApp.Application.Events.Queries.GetEvents;
public record GetEventsQuery : IRequest<IEnumerable<Event>>;

public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IEnumerable<Event>>
{
    private readonly IApplicationDbContext _context;
    public GetEventsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context.Events.ToListAsync();
        return entities;
    }
}


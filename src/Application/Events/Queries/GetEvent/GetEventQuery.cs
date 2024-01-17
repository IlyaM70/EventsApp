using EventsApp.Application.Exceptions;
using EventsApp.Application.Interfaces;
using EventsApp.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventsApp.Events.Queries.GetEvent;

public record GetEventQuery : IRequest<Event>
{
    public int Id { get; set; }
}

public class GetEventQueryHandler : IRequestHandler<GetEventQuery, Event>
{
    private readonly IApplicationDbContext _context;
    public GetEventQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Event> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Events.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

        if (entity == null)
        {
            throw new NotFoundException(nameof(Event), request.Id);
        }

        return entity;
    }
}

using EventsApp.Application.Exceptions;
using EventsApp.Application.Interfaces;
using EventsApp.Domain.Models;
using MediatR;

namespace EventsApp.Application.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateEventCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Events
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Event), request.Id);
        }

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Updated = DateTime.UtcNow;
        entity.Begining = request.Begining.ToUniversalTime();
        entity.Ending = request.Ending.ToUniversalTime();
        entity.ApplicationsDue = request.ApplicationsDue.ToUniversalTime();
        entity.IsCommercial = request.IsCommercial;
        entity.Address = request.Address;
        entity.MinPersons = request.MinPersons;
        entity.MinPersons = request.MaxPersons;
        entity.MinAge = request.MinAge;
        entity.MaxAge = request.MaxAge;
        entity.GenderRestrictions = request.GenderRestrictions;
        entity.MainEventId = request.MainEventId;
        entity.CategoryId = request.CategoryId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

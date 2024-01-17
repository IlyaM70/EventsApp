using EventsApp.Application.Interfaces;
using EventsApp.Domain.Models;
using MediatR;

namespace EventsApp.Application.Events.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEventCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        Event entity = new() 
        {
             Name = request.Name,
             Description = request.Description,
             CreaterId = request.CreaterId,
             Created = request.Created.ToUniversalTime(),
             Updated = request.Updated.ToUniversalTime(),
             Begining = request.Begining.ToUniversalTime(),
             Ending = request.Ending.ToUniversalTime(),
             ApplicationsDue = request.ApplicationsDue.ToUniversalTime(),
             IsCommercial = request.IsCommercial,
             Address = request.Address,
             MinPersons = request.MinPersons,
             MaxPersons = request.MaxPersons,
             MinAge = request.MinAge,
             MaxAge = request.MaxAge, 
             GenderRestrictions = request.GenderRestrictions,
             MainEventId = request.MainEventId,
             CategoryId = request.CategoryId,
        };
        

        _context.Events.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}

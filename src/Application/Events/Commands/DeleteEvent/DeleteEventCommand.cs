using EventsApp.Application.Exceptions;
using EventsApp.Application.Interfaces;
using EventsApp.Domain.Models;
using MediatR;

namespace EventsApp.Application.Events.Commands.DeleteEvent;

public record DeleteEventCommand(int Id) : IRequest;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteEventCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Events
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Event), request.Id);
        }

        _context.Events.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}

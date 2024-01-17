using EventsApp.Application.Events.Commands.CreateEvent;
using FluentValidation;

namespace EventsApp.Application.Events.Commands.UpdateEvent;

public class UpdateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(x => x.Description)
            .MaximumLength(200);

        RuleFor(x => x.Address)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(x => x.ApplicationsDue)
            .NotEmpty();

        RuleFor(x => x.Begining)
            .NotEmpty();

        RuleFor(x => x.Ending)
            .NotEmpty();

        RuleFor(x => x.MinPersons)
            .NotEmpty();

        RuleFor(x => x.MaxPersons)
            .NotEmpty();
    }
}

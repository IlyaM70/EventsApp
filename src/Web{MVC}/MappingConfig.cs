using AutoMapper;
using EventsApp.Application.Events.Commands.CreateEvent;
using EventsApp.Application.Events.Commands.UpdateEvent;
using EventsApp.Domain.Models;
using EventsApp.WebMVC.Models;


namespace EventsApp.WebMVC;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<EventViewModel, Event>();
        CreateMap<Event, EventViewModel>();

        CreateMap<EventViewModel, CreateEventCommand>();
        CreateMap<CreateEventCommand, EventViewModel>();

        CreateMap<EventViewModel, UpdateEventCommand>();
        CreateMap<UpdateEventCommand, EventViewModel>();
    }
}

using System.Security.Claims;
using AutoMapper;
using EventsApp.Application.Events.Commands.CreateEvent;
using EventsApp.Application.Events.Commands.DeleteEvent;
using EventsApp.Application.Events.Commands.UpdateEvent;
using EventsApp.Domain.Models;
using EventsApp.Events.Queries.GetEvent;
using EventsApp.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EventsApp.WebMVC.Controllers;
public class EventController : BaseController
{
    #region ctor
    private readonly IMapper _mapper;
    public EventController(IMapper mapper)
    {
        _mapper = mapper;
    }
    #endregion

    #region Details
    public async Task<IActionResult> Details(int id)
    {
        GetEventQuery getEventQuery = new();
        getEventQuery.Id = id;
        Event? eventItem = await Mediator.Send(getEventQuery);
        EventViewModel? eventView = _mapper.Map<EventViewModel>(eventItem);
        return View(eventView);
    }
    #endregion

    #region Upsert
    [Authorize]
    public async Task<IActionResult> Upsert(int? id = null, EventViewModel? eventView = null)
    {
        eventView = new EventViewModel();
        if (id != null && id !=0)
        {
            //Update
            GetEventQuery getEventQuery = new();
            getEventQuery.Id = (int)id;
            Event? eventItem = await Mediator.Send(getEventQuery);
            if (eventItem != null)
            {
                eventView = _mapper.Map<EventViewModel>(eventItem);
            }
            else
            {
                TempData["error"] = "Событие не найдено";
            }
        }

        return View(eventView);
    }

    // POST: EventController/Upsert/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<ActionResult> Upsert(EventViewModel eventItem,IFormCollection collection,int? id = null)
    {
        if (ModelState.IsValid)
        {
            if (id !=null && id!=0)
            {
                //update
                UpdateEventCommand updateEventCommand = new();
                updateEventCommand = _mapper.Map<UpdateEventCommand>(eventItem);
                TempData["success"] = "Событие обновлено";
                await Mediator.Send(updateEventCommand);
                return RedirectToAction("Upsert", eventItem);
            }

            //Create
            eventItem.CreaterId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            CreateEventCommand createEventCommand = new();
            createEventCommand = _mapper.Map<CreateEventCommand>(eventItem);
            await Mediator.Send(createEventCommand);
            TempData["success"] = "Событие создано";
        }
        else
        {
            TempData["error"] = "Произошла ошибка";
        }
        return RedirectToAction("Upsert", eventItem);
    }
    #endregion

    #region Delete
    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
        GetEventQuery getEventQuery = new();
        getEventQuery.Id = (int)id;
        Event? eventItem = await Mediator.Send(getEventQuery);
        EventViewModel eventView = _mapper.Map<EventViewModel>(eventItem);
        return View(eventView);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<ActionResult> Delete(int id, IFormCollection collection)
    {
        if (ModelState.IsValid)
        {
            GetEventQuery getEventQuery = new();
            getEventQuery.Id = id;
            Event? eventItemToDelete = await Mediator.Send(getEventQuery);

            if (eventItemToDelete != null)
            {
                DeleteEventCommand deleteEventCommand = new(id);
                await Mediator.Send(deleteEventCommand);
                TempData["success"] = "Событие удалено";
            }
            else
            {
                TempData["error"] = "Событие не найдено";
            }
        }
        else
        {
            TempData["error"] = "Произошла ошибка";
        }
        return RedirectToAction("Index","Home");
    }
    #endregion
}

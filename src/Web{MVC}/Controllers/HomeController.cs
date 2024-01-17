using System.Diagnostics;
using EventsApp.Application.Events.Queries.GetEvents;
using EventsApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using EventsApp.WebMVC.Models;
using AutoMapper;


namespace EventsApp.WebMVC.Controllers;
public class HomeController : BaseController
{
    #region ctor
    private readonly IMapper _mapper;
    public HomeController(IMapper mapper)
    {
        _mapper = mapper;
    }
    #endregion

    public async Task<IActionResult> Index()
    {
        GetEventsQuery query = new();
        List<Event>? events = await Mediator.Send(query) as List<Event>;
        List<EventViewModel> viewModel = _mapper.Map<List<EventViewModel>>(events);
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

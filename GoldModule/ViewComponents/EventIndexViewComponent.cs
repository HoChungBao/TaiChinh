using Gold.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.ViewComponents
{
    [ViewComponent(Name = "EventIndex")]
    public class EventIndexViewComponent : ViewComponent
    {
        private readonly IEventService _eventService;
        public EventIndexViewComponent(IEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, string search = "")
        {
            var pageevent = await _eventService.GetPagingList(page, 20, search);
            pageevent.Action = "Index";
            pageevent.RouteValue = new RouteValueDictionary(new { search = search });
            return View(pageevent);
        }
    }
}

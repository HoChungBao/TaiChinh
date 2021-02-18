using Gold.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.ViewComponents
{
    [ViewComponent(Name = "EventCreate")]
    public class EventCreateViewComponent : ViewComponent
    {
        private readonly IEventService _eventService;
        public EventCreateViewComponent(IEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

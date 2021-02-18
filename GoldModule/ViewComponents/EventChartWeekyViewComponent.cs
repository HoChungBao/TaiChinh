using Gold.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.ViewComponents
{
    [ViewComponent(Name = "EventChartWeeky")]
    public class EventChartWeekyViewComponent : ViewComponent
    {
        private readonly IEventService _eventService;
        public EventChartWeekyViewComponent(IEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task<IViewComponentResult> InvokeAsync(DateTime datefrom,DateTime dateto)
        {
            var data = _eventService.GetEventFromDateToDate(datefrom, dateto);
            return View(data);
        }
    }
}

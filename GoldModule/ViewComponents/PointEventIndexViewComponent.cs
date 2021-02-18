using Gold.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.ViewComponents
{
    [ViewComponent(Name = "PointEventIndex")]
    public class PointEventIndexViewComponent : ViewComponent
    {
        private readonly IPointEventService _pointEventService;
        public PointEventIndexViewComponent(IPointEventService pointEventService)
        {
            _pointEventService = pointEventService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, string search = "")
        {
            var pagepointevent = await _pointEventService.GetPagingList(page, 20, search);
            pagepointevent.Action = "Index";
            pagepointevent.RouteValue = new RouteValueDictionary(new { search = search });
            return View(pagepointevent);
        }
    }
}

using Gold.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.ViewComponents
{
    [ViewComponent(Name = "PointEventCreate")]
    public class PointEventCreateViewComponent : ViewComponent
    {
        private readonly IPointEventService _pointEventService;
        public PointEventCreateViewComponent(IPointEventService pointEventService)
        {
            _pointEventService = pointEventService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

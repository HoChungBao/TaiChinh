using Food.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.ViewComponents
{
    public class VegetableFruitCreateViewComponent : ViewComponent
    {
        private readonly IVegetableService _vegetableService;
        public VegetableFruitCreateViewComponent(IVegetableService vegetableService)
        {
            _vegetableService = vegetableService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, string search = "")
        {
            var pagevegetablefruit = await _vegetableService.GetPagingList(page, 20, search);
            pagevegetablefruit.Action = "Index";
            pagevegetablefruit.RouteValue = new RouteValueDictionary(new { search = search });
            return View(pagevegetablefruit);
        }
    }
}

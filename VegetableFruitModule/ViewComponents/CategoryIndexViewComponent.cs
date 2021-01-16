using Food.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegetableFruitModule.ViewComponents
{
    [ViewComponent(Name = "CategoryIndex")]
    public class CategoryIndexViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryIndexViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, string search = "")
        {
            var pagecategory = await _categoryService.GetPagingList(page, 20, search);
            pagecategory.Action = "Index";
            pagecategory.RouteValue = new RouteValueDictionary(new { search = search });
            return View(pagecategory);
        }
    }
}

using Food.Core.Interfaces;
using Infrastructure.Extensions.Validators;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegetableFruitModule.Models;
using VegetableFruitModule.Validators;

namespace VegetableFruitModule.Admin
{
    public class VegetableFruitController : Controller
    {
        private readonly IVegetableService _vegetableService;
        public VegetableFruitController(IVegetableService vegetableService)
        {
            _vegetableService = vegetableService;
        }
        public async Task<IActionResult> Index(int page = 1, string search = "")
        {
            ViewBag.ViewComponent = NameComponentView.VegetableFruitIndex;
            ViewBag.Page = page;
            ViewBag.Search = search;
            return View();
        }
        // GET: VegetableFruitController/Create
        public ActionResult Create()
        {
            ViewBag.ViewComponent = NameComponentView.CategoryCreate;
            return View();
        }

        // POST: VegetableFruitController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(VegetableFruitPostModel model)
        {
            var rs = new HttpContentResult<dynamic>();
            try
            {
                var vegertablefruitvalidator = new VegetableFruitValidator();
                var validate = vegertablefruitvalidator.Validate(model);
                if (!validate.IsValid)
                {
                    rs.Fail();
                    rs.Message = validate.GetErrorMessageValidator();
                    return Json(rs);
                }

                var vegertablefruit = model.InstanceEntity();
                _vegetableService.AddAsync(vegertablefruit);
                rs.Success();
                rs.Message = MessageResultJson.Success;
                return Json(rs);
            }
            catch
            {
                return Json(rs);
            }
        }
    }
}

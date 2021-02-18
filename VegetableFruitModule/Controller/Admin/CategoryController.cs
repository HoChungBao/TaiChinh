using Food.Core.Interfaces;
using Infrastructure.Extensions.Validators;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegetableFruitModule.Models;
using VegetableFruitModule.Validators;

namespace VegetableFruitModule.Admin
{
    [Authorize(Policy = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        //private readonly Iuser _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: CategoryController
        public async Task<IActionResult> Index(int page=1, string search="")
        {
            ViewBag.ViewComponent = NameComponentView.CategoryIndex;
            ViewBag.Page = page;
            ViewBag.Search = search;
            return View();
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            ViewBag.ViewComponent = NameComponentView.CategoryCreate;
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryPostModel model)
        {
            var rs =new HttpContentResult<dynamic>();
            try
            {
                var categroyvalidator = new CategoryValidator();
                var validate= categroyvalidator.Validate(model);
                if (!validate.IsValid)
                {
                    rs.Fail();
                    rs.Message= validate.GetErrorMessageValidator();
                    return Json(rs);
                }

                var category = model.InstanceEntity();
                //category.User = User.Identity.Name;
                await _categoryService.AddAsync(category);
                rs.Success();
                rs.Message = MessageResultJson.Success;
                return Json(rs);
            }
            catch
            {
                return Json(rs);
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

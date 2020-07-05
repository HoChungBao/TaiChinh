using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Interface;
using TaiChinh.Core.Model;

namespace TaiChinh
{
    public class TyLeController : Controller
    {
        private readonly ITyLeService _tyLeService;
        public TyLeController(ITyLeService tyLeService)
        {
            _tyLeService = tyLeService;
        }
        public IActionResult Index()
        {
            var tyLe = _tyLeService.GetAllTyLe();
            return View(tyLe);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var tyle = _tyLeService.GetAllTyLeByMonth();
            ViewBag.Total= 100 - tyle.Sum(x => x.Amount);
            return View();
        }

        [HttpPost]
        public IActionResult Create(TyLeModel model)
        {
            try
            {
                var tyLe = new TyLe()
                {
                    Name = model.Name,
                    Amount = model.Amount,
                    IsUse=model.IsUse,
                };
                _tyLeService.InsertTyLe(tyLe);
                return View(tyLe);
            }
            catch (Exception)
            {
                return View("Create");
            }
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            var tyLe = _tyLeService.GetTyLeById(id);
            return View(tyLe);
        }

        [HttpPost]
        public IActionResult Update(TyLeModel model)
        {
            try
            {
                var tyLe = _tyLeService.GetTyLeById(model.Id);
                tyLe.Name = model.Name;
                tyLe.Amount = model.Amount;
                tyLe.IsUse = model.IsUse;
                _tyLeService.UpdateTyLe(tyLe);
                return View(tyLe);
            }
            catch (Exception)
            {
                return View("Update");
            }
        }
        [HttpGet]
        public IActionResult Delete(long id)
        {
            var tyLe = _tyLeService.GetTyLeById(id);
            _tyLeService.DeleteTyLe(tyLe);
            return Json(new
            {
                Result = true
            });
        }
    }
}
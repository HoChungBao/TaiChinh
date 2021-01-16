using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Interface;
using TaiChinh.Core.Model;

namespace FinanceModule
{
    public class TyLeController : Controller
    {
        private readonly ITyLeService _tyLeService;
        public TyLeController(ITyLeService tyLeService)
        {
            _tyLeService = tyLeService;
        }
        public async Task<IActionResult> Index(int month)
        {
            month = month != 0 ? month : DateTime.Now.Month;
            var tyLe = await _tyLeService.GetAllTyLeByMonth(month);
            return View(tyLe);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var tyle = await _tyLeService.GetAllTyLeByMonth(DateTime.Now.Month);
            ViewBag.Total= 100 - tyle.Sum(x => x.Amount);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TyLeModel model)
        {
            try
            {
                var tyLe = new TyLe()
                {
                    Name = model.Name,
                    Amount = model.Amount,
                    IsUse = model.IsUse,
                };
               await _tyLeService.InsertTyLe(tyLe);
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
        public async Task<IActionResult> Update(TyLeModel model)
        {
            try
            {
                var tyLe =await _tyLeService.GetTyLeById(model.Id);
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
        public async Task<IActionResult> Delete(long id)
        {
            var tyLe =await _tyLeService.GetTyLeById(id);
            await _tyLeService.DeleteTyLe(tyLe);
            return Json(new
            {
                Result = true
            });
        }
    }
}
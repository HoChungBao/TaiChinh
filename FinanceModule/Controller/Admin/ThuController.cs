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
    public class ThuController : Controller
    {
        private readonly IThuService _thuService;
        private readonly ITaiKhoanService _taiKhoanService;
        public ThuController(IThuService thuService, ITaiKhoanService taiKhoanService)
        {
            _thuService = thuService;
            _taiKhoanService = taiKhoanService;
        }
        public async Task<IActionResult> Index(int month)
        {
            month = month != 0 ? month : DateTime.Now.Month;
            var thu = await _thuService.GetThuByMonth(month);
            return View(thu);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ThuModel model)
        {
            try
            {
                var thu = new Thu()
                {
                    Name = model.Name,
                    Money= model.Money,
                    TaiKhoanId=model.TaiKhoanId,
                };
                var taiKhoan = await _taiKhoanService.GetTaiKhoanById(model.TaiKhoanId);
                taiKhoan.Money += model.Money;
                await _taiKhoanService.UpdateTaiKhoan(taiKhoan);
                await _thuService.InsertThu(thu);
                return View(thu);
            }
            catch (Exception)
            {
                return View("Create");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(long id)
        {
            var thu = await _thuService.GetThuById(id);
            return View(thu);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ThuModel model)
        {
            try
            {
                var thu = await _thuService.GetThuById(model.Id);
                thu.Name = model.Name;
                thu.Money = model.Money;
                await _thuService.UpdateThu(thu);
                return View("Update", thu);
            }
            catch (Exception)
            {
                return View("Update");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var thu = await _thuService.GetThuById(id);
            await _thuService.DeleteThu(thu);
            return Json(new
            {
                Result = true
            });
        }

    }
}
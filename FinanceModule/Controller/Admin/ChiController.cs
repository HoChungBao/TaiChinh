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
    public class ChiController : Controller
    {
        private readonly IChiService _chiService;
        private readonly ITaiKhoanService _taiKhoanService;
        public ChiController(IChiService chiService, ITaiKhoanService taiKhoanService)
        {
            _chiService = chiService;
            _taiKhoanService = taiKhoanService;
        }
        public async Task<IActionResult> Index(int month)
        {
            month = month != 0 ? month : DateTime.Now.Month;
            var chi = await _chiService.GetChiByMonth(month);
            return View(chi);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChiModel model)
        {
            try
            {
                var chi = new Chi()
                {
                    Name = model.Name,
                    Money = model.Money,
                    TaiKhoanId= model.TaiKhoanId,
                    TyLeId = model.TyLeId,
                };
                var taiKhoan = await _taiKhoanService.GetTaiKhoanById(model.TaiKhoanId);
                taiKhoan.Money -= model.Money;
                await _taiKhoanService.UpdateTaiKhoan(taiKhoan);
                await _chiService.InsertChi(chi);
                return View(chi);
            }
            catch (Exception)
            {
                return View("Create");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(long id)
        {
            var chi = await _chiService.GetChiById(id);
            return View(chi);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ChiModel model)
        {
            try
            {
                var chi = await _chiService.GetChiById(model.Id);
                chi.Name = model.Name;
                //đổi tài khoản chi
                var taiKhoan = await _taiKhoanService.GetTaiKhoanById(chi.TaiKhoanId??0);
                if (chi.TaiKhoanId != model.TaiKhoanId)
                {

                    var taiKhoanChi = await _taiKhoanService.GetTaiKhoanById(model.TaiKhoanId);
                    if (taiKhoanChi != null)
                    {
                        taiKhoanChi.Money -= model.Money;
                        chi.TaiKhoanId = model.TaiKhoanId;
                        await _taiKhoanService.UpdateTaiKhoan(taiKhoanChi);
                    }
                    else
                    {
                        return View(chi);
                    }
                }
                else
                {
                    taiKhoan.Money -=model.Money;
                }
                chi.Money = model.Money;
                taiKhoan.Money += chi.Money;
               await  _chiService.UpdateChi(chi);
                await  _taiKhoanService.UpdateTaiKhoan(taiKhoan);
                return View(chi);
            }
            catch (Exception)
            {
                return View("Update");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var chi = await _chiService.GetChiById(id);
            await _chiService.DeleteChi(chi);
            return Json(new
            {
                Result = true
            });
        }
    }
}
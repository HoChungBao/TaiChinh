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
    public class ChiController : Controller
    {
        private readonly IChiService _chiService;
        private readonly ITaiKhoanService _taiKhoanService;
        public ChiController(IChiService chiService, ITaiKhoanService taiKhoanService)
        {
            _chiService = chiService;
            _taiKhoanService = taiKhoanService;
        }
        public IActionResult Index()
        {
            var chi = _chiService.GetAllChi();
            return View(chi);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ChiModel model)
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
                var taiKhoan = _taiKhoanService.GetTaiKhoanById(model.TaiKhoanId);
                taiKhoan.Money -= model.Money;
                _taiKhoanService.UpdateTaiKhoan(taiKhoan);
                _chiService.InsertChi(chi);
                return View(chi);
            }
            catch (Exception)
            {
                return View("Create");
            }
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            var chi = _chiService.GetChiById(id);
            return View(chi);
        }

        [HttpPost]
        public IActionResult Update(ChiModel model)
        {
            try
            {
                var chi = _chiService.GetChiById(model.Id);
                chi.Name = model.Name;
                //đổi tài khoản chi
                var taiKhoan = _taiKhoanService.GetTaiKhoanById(chi.TaiKhoanId??0);
                if (chi.TaiKhoanId != model.TaiKhoanId)
                {

                    var taiKhoanChi = _taiKhoanService.GetTaiKhoanById(model.TaiKhoanId);
                    if (taiKhoanChi != null)
                    {
                        taiKhoanChi.Money -= model.Money;
                        chi.TaiKhoanId = model.TaiKhoanId;
                        _taiKhoanService.UpdateTaiKhoan(taiKhoanChi);
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
                _chiService.UpdateChi(chi);
                _taiKhoanService.UpdateTaiKhoan(taiKhoan);
                return View(chi);
            }
            catch (Exception)
            {
                return View("Update");
            }
        }
        [HttpGet]
        public IActionResult Delete(long id)
        {
            var chi = _chiService.GetChiById(id);
            _chiService.DeleteChi(chi);
            return Json(new
            {
                Result = true
            });
        }
    }
}
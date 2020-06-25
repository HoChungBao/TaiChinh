using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Interface;
using TaiChinh.Core.Model;

namespace TaiChinh
{
    public class TaiKhoanController : Controller
    {
        private readonly ITaiKhoanService _taiKhoanService;
        public TaiKhoanController(ITaiKhoanService taiKhoanService)
        {
            _taiKhoanService = taiKhoanService;
        }
        public IActionResult Index()
        {
            var taiKhoan = _taiKhoanService.GetAllTaiKhoan();
            return View(taiKhoan);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaiKhoanModel model)
        {
            try
            {
                var taiKhoan = new TaiKhoan()
                {
                    Name = model.Name,
                    NumberAccount = model.NumberAccount
                };
                _taiKhoanService.InsertTaiKhoan(taiKhoan);
                return View("Create");
            }
            catch (Exception)
            {
                return View("Create");
            }
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            var taiKhoan = _taiKhoanService.GetTaiKhoanById(id);
            return View(taiKhoan);
        }

        [HttpPost]
        public IActionResult Update(TaiKhoanModel model)
        {
            try
            {
                var taiKhoan = _taiKhoanService.GetTaiKhoanById(model.Id);
                taiKhoan.Name = model.Name;
                taiKhoan.NumberAccount = model.NumberAccount;
                taiKhoan.Money = model.Money;
                taiKhoan.IsCash = model.IsCash;
                _taiKhoanService.UpdateTaiKhoan(taiKhoan);
                return View(taiKhoan);
            }
            catch (Exception)
            {
                return View("Update");
            }
        }
        [HttpGet]
        public IActionResult Delete(long id)
        {
            var taiKhoan = _taiKhoanService.GetTaiKhoanById(id);
            _taiKhoanService.DeleteTaiKhoan(taiKhoan    );
            return Json(new
            {
                Result = true
            });
        }

        [HttpGet]
        public IActionResult ThuChi(long id)
        {
            var taikhoan = _taiKhoanService.GetTaiKhoanThuChiById(id);
            return View(taikhoan);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Interface;
using TaiChinh.Core.Model;

namespace FinanceModule
{
    public class TaiKhoanController : Controller
    {
        private readonly ITaiKhoanService _taiKhoanService;
        public TaiKhoanController(ITaiKhoanService taiKhoanService)
        {
            _taiKhoanService = taiKhoanService;
        }
        public async Task<IActionResult> Index()
        {
            var taiKhoan =await _taiKhoanService.GetAllTaiKhoan();
            return View(taiKhoan);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaiKhoanModel model)
        {
            try
            {
                var taiKhoan = new TaiKhoan()
                {
                    Name = model.Name,
                    NumberAccount = model.NumberAccount
                };
                await _taiKhoanService.InsertTaiKhoan(taiKhoan);
                return View("Create");
            }
            catch (Exception)
            {
                return View("Create");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(long id)
        {
            var taiKhoan = await _taiKhoanService.GetTaiKhoanById(id);
            return View(taiKhoan);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaiKhoanModel model)
        {
            try
            {
                var taiKhoan = await _taiKhoanService.GetTaiKhoanById(model.Id);
                taiKhoan.Name = model.Name;
                taiKhoan.NumberAccount = model.NumberAccount;
                taiKhoan.Money = model.Money;
                taiKhoan.IsCash = model.IsCash;
                await _taiKhoanService.UpdateTaiKhoan(taiKhoan);
                return View(taiKhoan);
            }
            catch (Exception)
            {
                return View("Update");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var taiKhoan = await _taiKhoanService.GetTaiKhoanById(id);
            await _taiKhoanService.DeleteTaiKhoan(taiKhoan    );
            return Json(new
            {
                Result = true
            });
        }

        [HttpGet]
        //Chi tiết thu chi tiền của tài khoản
        public async Task<IActionResult> ThuChi(long id)
        {
            var taikhoan = await _taiKhoanService.GetTaiKhoanThuChiByIdYear(id,DateTime.Now.Year);
            return View(taikhoan);
        }

    }
}
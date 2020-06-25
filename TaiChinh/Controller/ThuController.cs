﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Interface;
using TaiChinh.Core.Model;

namespace TaiChinh
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
        public IActionResult Index()
        {
            var thu = _thuService.GetAllThu();
            return View(thu);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ThuModel model)
        {
            try
            {
                var thu = new Thu()
                {
                    Name = model.Name,
                    Money= model.Money,
                    TaiKhoanId=model.TaiKhoanId,
                };
                var taiKhoan = _taiKhoanService.GetTaiKhoanById(model.TaiKhoanId);
                taiKhoan.Money += model.Money;
                _taiKhoanService.UpdateTaiKhoan(taiKhoan);
                _thuService.InsertThu(thu);
                return View(thu);
            }
            catch (Exception)
            {
                return View("Create");
            }
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            var thu = _thuService.GetThuById(id);
            return View(thu);
        }

        [HttpPost]
        public IActionResult Update(ThuModel model)
        {
            try
            {
                var thu = _thuService.GetThuById(model.Id);
                thu.Name = model.Name;
                thu.Money = model.Money;
                _thuService.UpdateThu(thu);
                return View("Update", thu);
            }
            catch (Exception)
            {
                return View("Update");
            }
        }
        [HttpGet]
        public IActionResult Delete(long id)
        {
            var thu = _thuService.GetThuById(id);
            _thuService.DeleteThu(thu);
            return Json(new
            {
                Result = true
            });
        }

    }
}
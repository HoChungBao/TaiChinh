﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Interface;
using TaiChinh.Core.ViewModel;

namespace TaiChinh
{
    public class TienController : Controller
    {
        private readonly IThuService _thuService;
        private readonly IChiService _chiService;
        private readonly ITaiKhoanService _taiKhoanService;
        private readonly ITyLeService _tyLeService;
        public TienController(ITaiKhoanService taiKhoanService ,ITyLeService tyLeService ,IThuService thuService, IChiService chiService)
        {
            _thuService = thuService;
            _chiService = chiService;
            _taiKhoanService = taiKhoanService;
            _tyLeService =tyLeService;
        }
        public IActionResult Index()
        {
            DateTime date = DateTime.Now;
            int year = date.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            var dateF = new DateTime(date.Year, date.Month, 1);
            var dateT = dateF.AddMonths(1).AddDays(-1);
            var tien = new TienModel();

            //Tổng 
            tien.MoneyThuInYear = GetAllMoneyThuInYear(firstDay, lastDay);

            //Thu tiền
            tien.MoneyThuInMonth = GetAllMoneyThuInMonth(dateF, dateT);

            tien.MoneyThuInToDay = GetMoneyThuInToDay();

            //tien.TyLeThuInMonth = GetTyLeMoney(tien.MoneyThuInMonth);

            //tien.TyLeThuInToDay = GetTyLeMoney(tien.MoneyThuInToDay);


            //Chi tiền

            tien.MoneyChiInYear = GetAllMoneyChiInYear(firstDay, lastDay);

            tien.MoneyChiInMonth = GetAllMoneyChiInMonth(dateF, dateT);

            tien.MoneyChiInToDay = GetMoneyChiInToDay();

            //Tiền chi trong một tháng từng phần trăm
            //tien.TyLeChiInMonth = GetTyLeChi(tien.MoneyChiInMonth);

            //Tiền chi trong một ngày từng  phần trăm
            //tien.TyLeChiInToDay = GetTyLeChi(tien.MoneyChiInToDay);

            tien.TyLe = GetTyLe();
            tien.TyLeChi = GetTyLeChi(tien.ToTalMoneyThuInMonth, tien.ToTalMoneyChiToDay, tien.MoneyChiInMonth);
            tien.TyLeChiDay=GetChi(tien.ToTalMoneyThuInMonth, tien.ToTalMoneyChiToDay, tien.MoneyChiInMonth, date);
            return View(tien);
        }

        //Lấy tiền thu được trong năm này
        public List<Thu> GetAllMoneyThuInYear(DateTime dateF, DateTime dateT)
        {
            return _thuService.GetThuFromTo(dateF, dateT);
        }

        //Lấy tiền thu được trong tháng này
        public List<Thu> GetAllMoneyThuInMonth(DateTime dateF, DateTime dateT)
        {
            return _thuService.GetThuFromTo(dateF, dateT);
        }

        //Lấy tiền thu được trong hôm nay
        public List<Thu> GetMoneyThuInToDay()
        {
            var date=DateTime.Now;
            return _thuService.GetThuFromTo(date, date);
        }

        //Lấy tiền năm này được trong năm này
        public List<Chi> GetAllMoneyChiInYear(DateTime dateF, DateTime dateT)
        {
            return _chiService.GetChiFromTo(dateF, dateT);
        }

        //Lấy tiền chi trong tháng này
        public List<Chi> GetAllMoneyChiInMonth(DateTime dateF, DateTime dateT)
        {
            return _chiService.GetChiFromTo(dateF, dateT);
        }

        //Lấy tiền chi trong hôm nay
        public List<Chi> GetMoneyChiInToDay()
        {
            var date = DateTime.Now;
            return _chiService.GetChiFromTo(date, date);
        }

        //Lấy tiền thu được từng phần trăm
        //public List<TyLeMoney> GetTyLeMoney(List<Thu> money)
        //{
        //    var listTyLeMoney = new List<TyLeMoney>();
        //    GetTyLe().ForEach(x =>
        //    {
        //        money.Where(i => i.TyLeId == x.Id).Sum(i => i.Money);
        //        var tyLeMoney = new TyLeMoney()
        //        {
        //            Id = x.Id,
        //            Amount = x.Amount ?? 0,
        //            Name = x.Name,
        //            Money = money.Where(i => i.TyLeId == x.Id).Sum(i => i.Money)/x.Amount ?? 0,
        //        };
        //        listTyLeMoney.Add(tyLeMoney);
        //    });
        //    return listTyLeMoney;
        //}

        //Lấy tiền chi được từng phần trăm
        //public List<TyLeMoney> GetTyLeChi(List<Chi> money)
        //{
        //    var listTyLeMoney = new List<TyLeMoney>();
        //    GetTyLe().ForEach(x =>
        //    {
        //        money.Where(i => i.TyLeId == x.Id).Sum(i => i.Money);
        //        var tyLeMoney = new TyLeMoney()
        //        {
        //            Id=x.Id,
        //            Amount = x.Amount ?? 0,
        //            Name = x.Name,
        //            Money = money.Where(i => i.TyLeId == x.Id).Sum(i => i.Money)??0,
        //        };
        //        listTyLeMoney.Add(tyLeMoney);
        //    });
        //    return listTyLeMoney;
        //}

        //Lấy tiền được chi mỗi ngày
        public decimal GetAverageChiInDay(List<Chi> money)
        {
            var chi= money.Sum(i => i.Money);
            return chi??0;
        }
        //Lấy tỷ lệ
        public List<TyLe> GetTyLe()
        {
            return _tyLeService.GetAllTyLeByMonth();
        }
        //Lấy tiền được chi
        public List<TyLeMoney> GetTyLeChi(decimal ToTalMoneyThuInMonth, decimal ToTalMoneyChiToDay,List<Chi> MoneyChiInMonth)
        {
            var listTyLeMoney = new List<TyLeMoney>();
            GetTyLe().ForEach(x =>
            {
                //money.Where(i => i.TyLeId == x.Id).Sum(i => i.Money);
                var tyLeMoney = new TyLeMoney()
                {
                    Name = x.Name,
                    MoneyChiInMonth = (ToTalMoneyThuInMonth * x.Amount)/ 100, // Tiền được chi một tháng :Tổng tiền thu một tháng/tỷ lệ
                    MoneyChiMonth = MoneyChiInMonth.Where(i => i.TyLeId == x.Id).Sum(i => i.Money), //*Tiền chi một tháng  :Tổng tiền chi một tháng
                    MoneyChiInToDay = ToTalMoneyChiToDay,//Tiền được chi một ngày :Tổng tiền thu một ngày/tỷ lệ
                    MoneyChiToDay = MoneyChiInMonth.Where(i => i.TyLeId == x.Id&&i.DateCreate.Value.Day==DateTime.Now.Day).Sum(i => i.Money),//Tiền chi một ngày :Tổng tiền chi một ngày
                };
                listTyLeMoney.Add(tyLeMoney);
            });
            return listTyLeMoney;
        }

        //Lấy tiền được chi
        //ToTalMoneyThuInMonth tiền còn lại trong một tháng= tổng thu - tổng chi
        //ToTalMoneyChiToDay tiền còn lại trong một ngày=ToTalMoneyThuInMonth/ ngày còn lại
        public List<TyLeMoney> GetChi(decimal ToTalMoneyThuInMonth, decimal ToTalMoneyChiToDay, List<Chi> MoneyChiInMonth,DateTime date)
        {
            var listTyLeMoney = new List<TyLeMoney>();
            var ToTalMoneyThuMonth = ToTalMoneyThuInMonth - MoneyChiInMonth.Sum(x => x.Money);
            var day = DateTime.DaysInMonth(date.Year, date.Month);
            var MoneyChiToDay = ToTalMoneyThuMonth / (day - date.Day + 1);
            GetTyLe().ForEach(x =>
            {
                var money = x.IsUse == false ? (ToTalMoneyThuInMonth * x.Amount) / 100 : (ToTalMoneyThuMonth * x.Amount) / 100;
                var tyLeMoney = new TyLeMoney()
                {
                    Name = x.Name,
                    MoneyChiInMonth = money, // Tiền được chi một tháng :Tổng tiền thu một tháng/tỷ lệ
                    MoneyChiMonth = MoneyChiInMonth.Where(i => i.TyLeId == x.Id && i.DateCreate.Value.Date == DateTime.Now.Date).Sum(i => i.Money), //*Tiền chi một tháng  :Tổng tiền chi một tháng
                    MoneyChiInToDay = MoneyChiToDay,//Tiền được chi một ngày :Tổng tiền thu một ngày/tỷ lệ
                    MoneyChiToDay = MoneyChiInMonth.Where(i => i.TyLeId == x.Id && i.DateCreate.Value.Day == DateTime.Now.Day).Sum(i => i.Money),//Tiền chi một ngày :Tổng tiền chi một ngày
                };
                listTyLeMoney.Add(tyLeMoney);
            });
            return listTyLeMoney;
        }
    }
}
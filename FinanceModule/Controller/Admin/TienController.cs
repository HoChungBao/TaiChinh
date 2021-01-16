using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Interface;
using TaiChinh.Core.ViewModel;

namespace FinanceModule
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
        public async Task<IActionResult> Index()
        {
            DateTime date = DateTime.Now;
            int year = date.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            var dateF = new DateTime(date.Year, date.Month, 1);
            var dateT = dateF.AddMonths(1).AddDays(-1);
            var tien = new TienModel();

            //Tổng 
            tien.MoneyThuInYear = await GetAllMoneyThuInYear(firstDay, lastDay);

            //Thu tiền
         
            tien.MoneyThuInMonth = tien.MoneyThuInYear
                .Where(x => x.DateCreate.Value.Month == date.Month).ToList();

            tien.MoneyThuInToDay = tien.MoneyThuInMonth
                .Where(x => x.DateCreate.Value.Day == date.Day).ToList();

            //Chi tiền

            tien.MoneyChiInYear = await GetAllMoneyChiInYear(firstDay, lastDay);

            tien.MoneyChiInMonth = tien.MoneyChiInYear
                .Where(x => x.DateCreate.Value.Month == date.Month).ToList();

            tien.MoneyChiInToDay = tien.MoneyChiInMonth.
                Where(x=>x.DateCreate.Value.Day==date.Day).ToList();

            //Tỷ lệ
            tien.TyLeAll = await _tyLeService.GetAllTyLe();
            tien.TyLe = tien.TyLeAll.Where(x=>x.DateCreate.Value.Month==date.Month).ToList();

            //Tiền được chi tiêu tháng, ngày
            tien.TyLeChi = await GetTyLeChi(tien.TyLe, tien.ToTalMoneyChiMonth);

            //Tiền chi tiêu tháng, ngày
            tien.TyLeChiDay= await GetChi(tien.TyLe, tien.MoneyChiInMonth, date);
            return View(tien);
        }

        //Lấy tiền thu được trong năm này
        public async Task<List<Thu>> GetAllMoneyThuInYear(DateTime dateF, DateTime dateT)
        {
            return await _thuService.GetThuFromTo(dateF, dateT);
        }    

        //Lấy tiền năm này được trong năm này
        public async Task<List<Chi>> GetAllMoneyChiInYear(DateTime dateF, DateTime dateT)
        {
            return await _chiService.GetChiFromTo(dateF, dateT);
        }

        //Lấy tiền được chi
        public async Task<List<TyLeMoney>> GetTyLeChi(List<TyLe> tyle,decimal ToTalMoneyChiMonth)
        {
            var listTyLeMoney = new List<TyLeMoney>();
            tyle = tyle.Where(x => x.IsUse == true).ToList();
            var amount = tyle.Sum(x => x.Amount);
            tyle.ForEach(x =>
            {
                //money.Where(i => i.TyLeId == x.Id).Sum(i => i.Money);
                var tyLeMoney = new TyLeMoney()
                {
                    Name = x.Name,
                    // Tiền được chi một tháng :Tổng tiền thu một tháng/tỷ lệ
                    MoneyChiInMonth = (ToTalMoneyChiMonth * x.Amount)/ amount,
                 
                };
                tyLeMoney.MoneyChiInToDay =tyLeMoney.MoneyChiInMonth / DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                listTyLeMoney.Add(tyLeMoney);
            });
            return listTyLeMoney;
        }

        //Lấy tiền được chi
        //ToTalMoneyThuInMonth tiền còn lại trong một tháng= tổng thu - tổng chi
        //ToTalMoneyChiToDay tiền còn lại trong một ngày=ToTalMoneyThuInMonth/ ngày còn lại
        public Task<List<TyLeMoney>> GetChi(List<TyLe>tyle,List<Chi> MoneyChiInMonth,DateTime date)
        {
            var listTyLeMoney = new List<TyLeMoney>();
          
            var day = DateTime.DaysInMonth(date.Year, date.Month);
       
            tyle.ForEach(x =>
            {
               
                var tyLeMoney = new TyLeMoney()
                {
                    Name = x.Name,
                    //*Tiền chi một tháng  :Tổng tiền chi một tháng
                    MoneyChiMonth = MoneyChiInMonth
                    .Where(i => i.TyLeId == x.Id && i.DateCreate.Value.Date == date.Date)
                    .Sum(i => i.Money),
                    //Tiền chi một ngày :Tổng tiền chi một ngày
                    MoneyChiToDay = x.IsUse==true?MoneyChiInMonth
                    .Where(i => i.TyLeId == x.Id && i.DateCreate.Value.Day == date.Day)
                    .Sum(i => i.Money):0,
                };
                listTyLeMoney.Add(tyLeMoney);
            });
            return Task.FromResult(listTyLeMoney);
        }
    }
}
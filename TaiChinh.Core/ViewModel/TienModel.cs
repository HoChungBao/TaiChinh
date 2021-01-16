using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaiChinh.Core.Entities;

namespace TaiChinh.Core.ViewModel
{
    public class TienModel
    {
        //Lấy tất cả thu một năm
        public List<Thu> MoneyThuInYear { get; set; }
        //Lấy tất cả thu một tháng
        public List<Thu> MoneyThuInMonth { get; set; }
        //Lấy tất cả thu một ngày
        public List<Thu> MoneyThuInToDay { get; set; }
      
        public List<Chi> MoneyChiInYear { get; set; }
        public List<Chi> MoneyChiInMonth { get; set; }
        public List<Chi> MoneyChiInToDay { get; set; }
        //Lấy tỷ lệ chi từng tháng, ngày
        public List<TyLeMoney> TyLeChi { get; set; }
        public List<TyLeMoney> TyLeChiDay { get; set; }
        public List<TyLe> TyLeAll { get; set; }
        public List<TyLe> TyLe { get; set; }
        ///<summary>
        ///Tiền tiết kiệm không được dùng năm
        ///</summary>
        public decimal TotalMoneyNotUseInYear {
            get => TyLeAll.Where(x => x.IsUse != true)
                .GroupBy(x => x.DateCreate.Value.Month)
                .Select(x => new { Amount = x.Sum(p => p.Amount), Month = x.Key }).ToList()
                .Sum(x => (MoneyThuInYear.Where(m => m.DateCreate.Value.Month == x.Month)
                        .Sum(m => m.Money) * x.Amount) / 100) ?? 0;
        }
        ///<summary>
        ///Tiền tiết kiệm không được dùng tháng
        ///</summary>
        public decimal TotalMoneyNotUseInMonth { get => (ToTalMoneyThuInMonth* TyLe.Where(x=>x.IsUse!=true).Sum(x=>x.Amount))/100 ?? 0; }
        ///<summary>
        ///Tiền thu được trong năm
        ///</summary> 
        public decimal ToTalMoneyThuInYear { get => MoneyThuInYear.Sum(x => x.Money) ?? 0; }
        ///<summary>
        ///Tiền chi trong năm
        ///</summary>
        public decimal ToTalMoneyChiInYear { get => MoneyChiInYear.Sum(x => x.Money) ?? 0; }
        ///<summary>
        ///Tiền thu được trong tháng
        ///</summary>
        public decimal ToTalMoneyThuInMonth { get => MoneyThuInMonth.Sum(x => x.Money) ?? 0; }
        ///<summary>
        ///Tiền thu được trong ngày
        ///</summary>
        public decimal ToTalMoneyThuInToDay { get => MoneyThuInToDay.Sum(x => x.Money) ?? 0; }
        ///<summary>
        ///Tiền chi trong tháng
        ///</summary>
        public decimal ToTalMoneyChiInMonth { get => MoneyChiInMonth.Sum(x => x.Money) ?? 0; }
        ///<summary>
        ///Tiền chi trong tháng
        ///</summary>
        public decimal ToTalMoneyChiInToDay { get => MoneyChiInToDay.Sum(x => x.Money) ?? 0; }
        ///<summary>
        ///Tiền được chi trong tháng
        ///</summary>
        public decimal ToTalMoneyChiMonth { get => (MoneyThuInMonth.Sum(x => x.Money) - TotalMoneyNotUseInMonth) ?? 0; }
        ///<summary>
        ///Tiền được chi trong ngày
        ///</summary>
        public decimal ToTalMoneyChiToDay { get => (MoneyThuInMonth.Sum(x => x.Money)- TotalMoneyNotUseInMonth) / DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)?? 0; }

    }
}

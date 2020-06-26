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
        //public List<TyLeMoney> TyLeThuInMonth { get; set; }
        //public List<TyLeMoney> TyLeThuInToDay { get; set; }
        public List<Chi> MoneyChiInYear { get; set; }
        public List<Chi> MoneyChiInMonth { get; set; }
        public List<Chi> MoneyChiInToDay { get; set; }
        //Lấy tỷ lệ chi từng tháng, ngày
        public List<TyLeMoney> TyLeChi { get; set; }
        //public List<TyLeMoney> TyLeChiInToDay { get; set; }
        public List<TyLe> TyLe { get; set; }
        public decimal ToTalMoneyThuInYear { get => MoneyThuInYear.Sum(x => x.Money) ?? 0; }
        public decimal ToTalMoneyChiInYear { get => MoneyChiInYear.Sum(x => x.Money) ?? 0; }

        public decimal ToTalMoneyThuInMonth { get => MoneyThuInMonth.Sum(x => x.Money) ?? 0; }
        public decimal ToTalMoneyThuInToDay { get => MoneyThuInToDay.Sum(x => x.Money) ?? 0; }
        public decimal ToTalMoneyChiInMonth { get => MoneyChiInMonth.Sum(x => x.Money) ?? 0; }
        public decimal ToTalMoneyChiInToDay { get => MoneyChiInToDay.Sum(x => x.Money) ?? 0; }
        public decimal ToTalMoneyChiToDay { get => MoneyThuInMonth.Sum(x => x.Money)/ DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) ?? 0; }

    }
}

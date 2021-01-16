using System;
using System.Collections.Generic;

namespace TaiChinh.Core.Entities
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            Chi = new HashSet<Chi>();
            ThuTaiKhoan = new HashSet<Thu>();
            ThuTaiKoanChuyen = new HashSet<Thu>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string NumberAccount { get; set; }
        public decimal? Money { get; set; }
        public bool? IsCash { get; set; }

        public virtual ICollection<Chi> Chi { get; set; }
        public virtual ICollection<Thu> ThuTaiKhoan { get; set; }
        public virtual ICollection<Thu> ThuTaiKoanChuyen { get; set; }
    }
}

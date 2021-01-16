using System;
using System.Collections.Generic;

namespace TaiChinh.Core.Entities
{
    public partial class Thu
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal? Money { get; set; }
        public DateTime? DateCreate { get; set; }
        public long? TaiKhoanId { get; set; }
        public long? TaiKoanChuyenId { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual TaiKhoan TaiKoanChuyen { get; set; }
    }
}

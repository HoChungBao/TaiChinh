using System;
using System.Collections.Generic;
using System.Text;

namespace TaiChinh.Core.Model
{
    public class ChiModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public DateTime? DateCreate { get; set; }
        public long TaiKhoanId { get; set; }
        public long TyLeId { get; set; }
    }
}

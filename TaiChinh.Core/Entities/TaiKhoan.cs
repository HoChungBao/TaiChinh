using System;
using System.Collections.Generic;

namespace TaiChinh.Core.Entities
{
    public partial class TaiKhoan
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NumberAccount { get; set; }
        public decimal? Money { get; set; }
    }
}

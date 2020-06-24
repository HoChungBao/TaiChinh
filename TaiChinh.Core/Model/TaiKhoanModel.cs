using System;
using System.Collections.Generic;
using System.Text;

namespace TaiChinh.Core.Model
{
    public class TaiKhoanModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NumberAccount { get; set; }
        public decimal? Money { get; set; }
        public bool? IsCash { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TaiChinh.Core.Model
{
    public class TyLeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public DateTime? DateCreate { get; set; }
        public bool? IsUse { get; set; }
    }
}

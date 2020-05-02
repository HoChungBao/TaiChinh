using System;
using System.Collections.Generic;

namespace TaiChinh.Core.Entities
{
    public partial class TyLe
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}

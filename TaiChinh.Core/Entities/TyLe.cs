using System;
using System.Collections.Generic;

namespace TaiChinh.Core.Entities
{
    public partial class TyLe
    {
        public TyLe()
        {
            Chi = new HashSet<Chi>();
            Thu = new HashSet<Thu>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public DateTime? DateCreate { get; set; }

        public virtual ICollection<Chi> Chi { get; set; }
        public virtual ICollection<Thu> Thu { get; set; }
    }
}

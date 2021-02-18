using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gold.Core.Entities
{
    public class GoldContext: DbContext
    {
        public GoldContext() 
        { 
        }
        public GoldContext(DbContextOptions<GoldContext> options):base(options)
        {

        }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<PointEvent> PointEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AUC9J69;Database=Gold;Trusted_Connection=True; user=sa;password=123456");
            }
        }
    }
}

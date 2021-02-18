using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Food.Core.Entities
{
    public partial class FoodContext : DbContext
    {
        public FoodContext()
        {
        }

        public FoodContext(DbContextOptions<FoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<VegetableFruit> VegetableFruit { get; set; }
        public virtual DbSet<Price> Price { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-AUC9J69;Database=Food;Trusted_Connection=True; user=sa;password=123456");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.InverseCategoryNavigation)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Category_Category");
            });

            modelBuilder.Entity<VegetableFruit>(entity =>
            {
                entity.ToTable("Vegetable_Fruit");

                entity.HasKey(e => e.Id).HasName("Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.VegetableFruit)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Vegetable_Fruit_Category");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price");
                entity.HasKey(e => e.Id).HasName("Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.VegetableFruit)
                      .WithMany(p => p.InversePriceNavigation)
                      .HasForeignKey(d => d.VegetableFruitId)
                      .HasConstraintName("FK_Price_Vegetable_Fruit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

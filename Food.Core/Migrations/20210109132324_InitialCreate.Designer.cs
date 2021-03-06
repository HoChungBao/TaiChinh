﻿// <auto-generated />
using System;
using Food.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Food.Core.Migrations
{
    [DbContext(typeof(FoodContext))]
    [Migration("20210109132324_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Food.Core.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<Guid?>("User")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Food.Core.Entities.VegetableFruit", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<Guid?>("User")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VideoLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Vegetable_Fruit");
                });

            modelBuilder.Entity("Food.Core.Entities.Category", b =>
                {
                    b.HasOne("Food.Core.Entities.Category", "CategoryNavigation")
                        .WithMany("InverseCategoryNavigation")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Category_Category");
                });

            modelBuilder.Entity("Food.Core.Entities.VegetableFruit", b =>
                {
                    b.HasOne("Food.Core.Entities.Category", "Category")
                        .WithMany("VegetableFruit")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Vegetable_Fruit_Category");
                });
#pragma warning restore 612, 618
        }
    }
}

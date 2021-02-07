using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Car;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> Brands { get; set; }
        public DbSet<CarColor> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<CarBrand>().ToTable("Brands");
            modelBuilder.Entity<CarBrand>().Property(p => p.CarBrandId).HasColumnName("BrandId");
            modelBuilder.Entity<CarBrand>().Property(p => p.CarBrandName).HasColumnName("BrandName");

            modelBuilder.Entity<CarColor>().ToTable("Colors");
            modelBuilder.Entity<CarColor>().Property(p => p.CarColorId).HasColumnName("ColorId");
            modelBuilder.Entity<CarColor>().Property(p => p.CarColorName).HasColumnName("ColorName");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BookStack.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStack.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductTypes> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductTypes>().HasKey(k => k.Id).HasName("ProductTypeId");
            builder.Entity<ProductTypes>()
                .Property(p => p.ProductName)
                .HasColumnName("ProductTypeName")
                .HasColumnType("varchar(200)")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}

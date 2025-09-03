using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Domain.Order.Models;
using Inventory.Domain.Product.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrasturcture.Common.DataContext
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<Product> Products { get; set; }        
        public DbSet<Order> Orders { get; set; }    
        public DbSet<OrderItem> orderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property<uint>("xmin") // PostgreSQL system column
                .IsRowVersion()
                .IsConcurrencyToken();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>()
        //        .HasMany(o => o.Items)
        //        .WithOne(i => i.Order)
        //        .HasForeignKey(i => i.OrderId);

        //    modelBuilder.Entity<OrderItem>()
        //        .HasOne(i => i.Product)
        //        .WithMany(p => p.OrderItems)
        //        .HasForeignKey(i => i.ProductId);

        //    modelBuilder.Entity<Product>()
        //        .Property(p => p.RowVersion)
        //        .IsRowVersion();
        //}
    }
}

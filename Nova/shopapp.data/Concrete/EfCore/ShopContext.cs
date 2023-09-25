using Microsoft.EntityFrameworkCore;
using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopapp.data.Concrete.EfCore
{
    public class ShopContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public ShopContext(DbContextOptions options) : base(options) 
        { 
        
        }    

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //TrustServerCertificate=true,

        //    optionsBuilder.UseSqlServer("Server= LAPTOP-I5A7DU4B;Database=shopappdb;User Id = sa;Password=123456;TrustServerCertificate=true;" +
        //        "MultipleActiveResultSets=True");
            
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(c => new { c.CategoryId, c.ProductId });

            //örnekleri yap aliştirma olsun diye
            //burada coka cok ilişk olmaıs lazım ama olmamış. fluent api kullanımına önem versek iyi olur
        }
    }
}

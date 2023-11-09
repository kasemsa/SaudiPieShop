﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace SaudiPieShop.Models
{
    public class SaudiPieShopDbContext :IdentityDbContext{
        public SaudiPieShopDbContext(DbContextOptions<SaudiPieShopDbContext> options):base(options)
        { 
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie>  Pies { get; set; }  
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}

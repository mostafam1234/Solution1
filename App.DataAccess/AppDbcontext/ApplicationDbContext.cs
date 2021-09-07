using App.DataAccess.Mapping;
using App.Logic;
using App.Logic.Domain;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Pie> Pies { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<ShoppingCartItem> items { set; get; }
        public DbSet<OrderDetail> orderDetails { set; get; }
        public DbSet<Order> orders { set; get; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDetailConfiguration).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Pieconfig).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);



        }


    }
}

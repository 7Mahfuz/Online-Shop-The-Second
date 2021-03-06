﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShopping_Application.Models;
namespace OnlineShopping_Application.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("OnlineShopContext", throwIfV1Schema: false)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartToDeliver> CartToDeliver { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
    }
}
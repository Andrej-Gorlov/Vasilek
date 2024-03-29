﻿using Microsoft.EntityFrameworkCore;
using Vasilek.Services.ShoppingCart.CouponAPI.Models;

namespace Vasilek.Services.ShoppingCart.CouponAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}

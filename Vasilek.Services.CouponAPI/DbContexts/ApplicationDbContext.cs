using Microsoft.EntityFrameworkCore;
using Vasilek.Services.CouponAPI.Models;

namespace Vasilek.Services.CouponAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}

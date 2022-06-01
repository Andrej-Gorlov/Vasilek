using Microsoft.EntityFrameworkCore;

namespace Vasilek.Services.ShoppingCart.CouponAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Vasilek.Services.OrderAPI.Models;

namespace Vasilek.Services.OrderAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<OrderHeader>()
        //        .Property(e => e.PickupDateTime)
        //        .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'")
        //        .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Unspecified));

        //    modelBuilder
        //       .Entity<OrderHeader>()
        //       .Property(e => e.OrderTime)
        //       .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'")
        //       .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Unspecified));
        //}
    }
}

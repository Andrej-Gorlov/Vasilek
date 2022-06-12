using Microsoft.EntityFrameworkCore;
using Vasilek.Services.Email.Models;

namespace Vasilek.Services.Email.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<EmailLog> EmailLogs { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<EmailLog>()
        //        .Property(e => e.EmailSent)
        //        .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'")
        //        .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Unspecified));
        //}
    }
}

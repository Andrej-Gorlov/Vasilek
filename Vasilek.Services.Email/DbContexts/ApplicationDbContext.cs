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
    }
}

using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Vasilek.Services.Identity.DbContexts;
using Vasilek.Services.Identity.Models;

namespace Vasilek.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
                             RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(StaticDetiels.Admin).Result==null)
            {
                _roleManager.CreateAsync(new IdentityRole(StaticDetiels.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetiels.Customer)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PasswordHash = "123456789",
                FirstName ="Polo",
                LastName ="Crid"
            };

            _userManager.CreateAsync(adminUser,"Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser,StaticDetiels.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,adminUser.FirstName+" "+adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                new Claim(JwtClaimTypes.Role,StaticDetiels.Admin),
            }).Result;

            ApplicationUser custemerUser = new ApplicationUser()
            {
                UserName = "custemer@gmail.com",
                Email = "custemer@gmail.com",
                EmailConfirmed = true,
                PasswordHash = "123456789",
                FirstName = "Don",
                LastName = "custemer"
            };

            _userManager.CreateAsync(custemerUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(custemerUser, StaticDetiels.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(custemerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,custemerUser.FirstName+" "+custemerUser.LastName),
                new Claim(JwtClaimTypes.GivenName,custemerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,custemerUser.LastName),
                new Claim(JwtClaimTypes.Role,StaticDetiels.Customer),
            }).Result;
        }
    }
}

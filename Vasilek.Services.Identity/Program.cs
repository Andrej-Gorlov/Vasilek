using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vasilek.Services.Identity;
using Vasilek.Services.Identity.DbContexts;
using Vasilek.Services.Identity.Initializer;
using Vasilek.Services.Identity.Models;
using Vasilek.Services.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

var bild = builder.Services.AddIdentityServer(x =>
{
    x.Events.RaiseErrorEvents = true;
    x.Events.RaiseInformationEvents = true;
    x.Events.RaiseFailureEvents = true;
    x.Events.RaiseSuccessEvents = true;
    x.EmitStaticAudienceClaim = true;//генерация статических требований
}).AddInMemoryIdentityResources(StaticDetiels.IdentityResource)
.AddInMemoryApiScopes(StaticDetiels.apiScopes)
.AddInMemoryClients(StaticDetiels.Clients)
.AddAspNetIdentity<ApplicationUser>();


builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IProfileService, ProfileService>();

bild.AddDeveloperSigningCredential();//create auto ключ


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();//add identityServer

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    IDbInitializer dbInitializer = service.GetRequiredService<IDbInitializer>();
    dbInitializer.Initialize();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

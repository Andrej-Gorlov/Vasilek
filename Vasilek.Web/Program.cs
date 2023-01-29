using Microsoft.AspNetCore.Authentication;
using Vasilek.Web;
using Vasilek.Web.Services;
using Vasilek.Web.Services.Implementations.ProductAPI;
using Vasilek.Web.Services.Interfaces.IProductAPI;
using Vasilek.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<ICategoryService, CategoryService>();
builder.Services.AddHttpClient<IShoppingCartService, ShoppingCartService>();
builder.Services.AddHttpClient<ICouponService, CouponService>();

StaticDitels.ProductApiBase = builder.Configuration["ServiseUrl:ProductAPI"];
StaticDitels.ShoppingCartApiBase = builder.Configuration["ServiseUrl:ShoppingCartAPI"];
StaticDitels.CouponApiBase = builder.Configuration["ServiseUrl:CouponAPI"];

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<ICouponService, CouponService>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(x =>
{
    x.DefaultScheme = "Cookies";
    x.DefaultChallengeScheme = "oidc";
})
                .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = builder.Configuration["ServiseUrl:IdentityAPI"];
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ClientId = "vasilek";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";
                    options.ClaimActions.MapJsonKey("role", "role", "role");
                    options.ClaimActions.MapJsonKey("sub", "sub", "sub");
                    options.TokenValidationParameters.NameClaimType = "name";
                    options.TokenValidationParameters.RoleClaimType = "role";
                    options.Scope.Add("vasilek");
                    options.SaveTokens = true;

                });

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
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

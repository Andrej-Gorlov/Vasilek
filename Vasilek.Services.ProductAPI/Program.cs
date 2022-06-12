using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductAPI.DAL;
using ProductAPI.DAL.Interfaces;
using ProductAPI.DAL.Repository;
using ProductAPI.Service.Implementations;
using ProductAPI.Service.Interfaces;
using System.Reflection;
using Vasilek.Services.ProductAPI;
using Vasilek.Services.ProductAPI.Middleware.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");  
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", x =>
{
    x.Authority = "https://localhost:7172/";
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false
    };
});
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "vasilek");
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ProductAPI",
        Description = "Пример Web API.",
        TermsOfService = new Uri("https://yandex.ru"),
        Contact = new OpenApiContact
        {
            Name = "Горлов Андрей",
            Email = "avgorlov899@gmail.com",
            Url = new Uri("https://github.com/Andrej-Gorlov?tab=repositories")
        },
        License = new OpenApiLicense
        {
            Name = "Лицензия...",
            Url = new Uri("https://github.com/Andrej-Gorlov?tab=repositories")
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Scheme="oauth2",
                Name="Bearer",
                In=ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(SwaggerUIOptions =>
    {
        SwaggerUIOptions.DocumentTitle = "ProductAPI";
    });
}

app.UseErrorHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

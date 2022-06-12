using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Vasilek.MessageBus;
using Vasilek.Services.OrderAPI.DbContexts;
using Vasilek.Services.OrderAPI.Extension;
using Vasilek.Services.OrderAPI.Messaging;
using Vasilek.Services.OrderAPI.RabbitMQSender;
using Vasilek.Services.OrderAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(connectionString));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddHostedService<RabbitMQPaymentConsumer>();
builder.Services.AddHostedService<RabbitMQCheckoutConsumer>();// авто запуск 
builder.Services.AddSingleton(new OrderRepository(optionBuilder.Options));
//builder.Services.AddSingleton<IAzureServiceBusConsumer, AzureServiceBusConsumer>();
//builder.Services.AddSingleton<IMessageBus, AzureServiceBusMessageBus>();
builder.Services.AddSingleton<IRabbitMQOrderMessageSender, RabbitMQOrderMessageSender>();

builder.Services.AddControllers();


builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", x =>
{
    x.Authority = "https://localhost:7172/";//url Vasilek.Services.Identity
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

//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mango.Services.CouponAPI", Version = "v1" });
    c.EnableAnnotations();

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//app.UseAzureServiceBusConsumer();

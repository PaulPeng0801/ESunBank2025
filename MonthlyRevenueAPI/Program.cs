using Microsoft.EntityFrameworkCore;
using MonthlyRevenueAPI.Models;
using MonthlyRevenueAPI.Profiles;
using MonthlyRevenueAPI.Repositories.Interface;
using MonthlyRevenueAPI.Repositories;
using MonthlyRevenueAPI.Services.Interface;
using MonthlyRevenueAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // 允許所有來源
              .AllowAnyHeader()   // 允許任何header
              .AllowAnyMethod();  // 允許GET, POST, PUT, DELETE等方法
    });
});

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Service與Interface
builder.Services.AddScoped<IMonthlyRevenueService, MonthlyRevenueService>();

// Repository
builder.Services.AddScoped<IMonthlyRevenueRepository, MonthlyRevenueRepository>();

// DbContext
builder.Services.AddDbContext<PublicCompanyContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Filters
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalException>();
});

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

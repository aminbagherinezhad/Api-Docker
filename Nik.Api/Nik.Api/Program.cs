using Microsoft.EntityFrameworkCore;
using Nik.Api.Models;
using Nik.Api.Services.Implemention;
using Nik.Api.Services.Interfaces;
using Nik.Api.Utilities.FileHelpers;
using System.ComponentModel;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(option =>
    {
        option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        option.JsonSerializerOptions.WriteIndented = true;
    });
builder.Services.AddDbContext<NikDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContextConnection"));
});
builder.Services.AddTransient<NikDbContext>();
builder.Services.AddScoped<IFileHelper, FileHelper>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICategoryImageRepository, categoryImageRepository>();
builder.Services.AddScoped<ISlidersRepository, SliderRepository>();
builder.Services.AddScoped<IAchievementRepository, AchievementRepository>();
builder.Services.AddScoped<ICompanyLogoRepository, CompanyLogoRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
});
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();

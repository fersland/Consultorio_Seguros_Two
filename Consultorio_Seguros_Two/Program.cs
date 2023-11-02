using Consultorio_Seguros.Models;
using Consultorio_Seguros.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDbConnection>(options =>
    new SqlConnection(builder.Configuration.GetConnectionString("db")));
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("name=db"));
builder.Services.AddScoped<IClienteRepo, ClienteRepo>();
builder.Services.AddScoped<ISeguroRepo, SeguroRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

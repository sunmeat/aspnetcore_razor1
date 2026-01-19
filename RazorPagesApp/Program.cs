using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

var builder = WebApplication.CreateBuilder(args);

// рядок підключення з файлу конфігурації (appsettings.json)
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connection));

// підтримка Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();

// маршрутизація на основі файлів .cshtml у папці Pages
// без цієї строчки Razor Pages взагалі не працюватимуть
app.MapRazorPages();

app.Run();
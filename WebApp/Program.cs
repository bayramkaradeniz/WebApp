using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApp.Models.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext service.
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});

// Add Session service
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum s�resini 30 dakika olarak ayarlad�k.
    options.Cookie.HttpOnly = true; // G�venlik i�in �erezleri sadece HTTP �zerinden eri�ilebilir yapar.
    options.Cookie.IsEssential = true; // Kullan�c�n�n gizlilik tercihine bak�lmaks�z�n �erezlerin gerekli oldu�unu belirtir.
});

// Add authentication services.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Set the login URL
        options.AccessDeniedPath = "/Login/AccessDenied"; // Optional: Set access denied URL
    });

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

// Use authentication and authorization.
app.UseAuthentication();
app.UseAuthorization();

// Use Session middlewares
app.UseSession();

app.MapControllerRoute(
    name: "title",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();

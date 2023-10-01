using Microsoft.EntityFrameworkCore;
using Cosmos.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add MySQL
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string not found");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connectionString));

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

app.UseAuthorization();

app.MapControllerRoute(
	name: "brief",
	pattern: "brief",
	defaults: new { controller = "Home", action = "Brief" });

/**
 * ADMIN ROUTES
 */

 // Games
app.MapControllerRoute(
	name: "games",
	pattern: "admin/games",
	defaults: new { controller = "Games", action = "Index" });

app.MapControllerRoute(
	name: "games",
	pattern: "admin/games/create",
	defaults: new { controller = "Games", action = "Create" });

 // Developers
app.MapControllerRoute(
	name: "developers",
	pattern: "admin/developers",
	defaults: new { controller = "Developers", action = "Index" });

app.MapControllerRoute(
	name: "developers",
	pattern: "admin/developers/create",
	defaults: new { controller = "Developers", action = "Create" });

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

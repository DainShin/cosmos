using Microsoft.EntityFrameworkCore;
using Cosmos.Models;
using Microsoft.Extensions.FileProviders;

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

// Genres
app.MapControllerRoute(
	name: "genres",
	pattern: "admin/genres",
	defaults: new { controller = "Genres", action = "Index" });

app.MapControllerRoute(
	name: "genres",
	pattern: "admin/genres/create",
	defaults: new { controller = "Genres", action = "Create" });

app.MapControllerRoute(
	name: "genres",
	pattern: "admin/genres/edit",
	defaults: new { controller = "Genres", action = "Edit" });

app.MapControllerRoute(
	name: "genres",
	pattern: "admin/genres/details",
	defaults: new { controller = "Genres", action = "Details" });

app.MapControllerRoute(
	name: "genres",
	pattern: "admin/genres/delete",
	defaults: new { controller = "Genres", action = "Delete" });

// Modes
app.MapControllerRoute(
	name: "modes",
	pattern: "admin/modes",
	defaults: new { controller = "Modes", action = "Index" });

app.MapControllerRoute(
	name: "modes",
	pattern: "admin/modes/create",
	defaults: new { controller = "Modes", action = "Create" });

app.MapControllerRoute(
	name: "modes",
	pattern: "admin/modes/edit",
	defaults: new { controller = "Modes", action = "Edit" });

app.MapControllerRoute(
	name: "modes",
	pattern: "admin/modes/details",
	defaults: new { controller = "Modes", action = "Details" });

app.MapControllerRoute(
	name: "modes",
	pattern: "admin/modes/delete",
	defaults: new { controller = "Modes", action = "Delete" });

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
	name: "developers",
	pattern: "admin/developers/edit",
	defaults: new { controller = "Developers", action = "Edit" });

app.MapControllerRoute(
	name: "developers",
	pattern: "admin/developers/details",
	defaults: new { controller = "Developers", action = "Details" });

app.MapControllerRoute(
	name: "developers",
	pattern: "admin/developers/delete",
	defaults: new { controller = "Developers", action = "Delete" });

// Publishers
app.MapControllerRoute(
	name: "publishers",
	pattern: "admin/publishers",
	defaults: new { controller = "Publishers", action = "Index" });

app.MapControllerRoute(
	name: "publishers",
	pattern: "admin/publishers/create",
	defaults: new { controller = "Publishers", action = "Create" });

app.MapControllerRoute(
	name: "publishers",
	pattern: "admin/publishers/edit",
	defaults: new { controller = "Publishers", action = "Edit" });

app.MapControllerRoute(
	name: "publishers",
	pattern: "admin/publishers/details",
	defaults: new { controller = "Publishers", action = "Details" });

app.MapControllerRoute(
	name: "publishers",
	pattern: "admin/publishers/delete",
	defaults: new { controller = "Publishers", action = "Delete" });

// Subscriptions
app.MapControllerRoute(
	name: "subscriptions",
	pattern: "admin/subscriptions",
	defaults: new { controller = "Subscriptions", action = "Index" });

app.MapControllerRoute(
	name: "subscriptions",
	pattern: "admin/subscriptions/create",
	defaults: new { controller = "Subscriptions", action = "Create" });

app.MapControllerRoute(
	name: "subscriptions",
	pattern: "admin/subscriptions/edit",
	defaults: new { controller = "Subscriptions", action = "Edit" });

app.MapControllerRoute(
	name: "subscriptions",
	pattern: "admin/subscriptions/details",
	defaults: new { controller = "Subscriptions", action = "Details" });

app.MapControllerRoute(
	name: "subscriptions",
	pattern: "admin/subscriptions/delete",
	defaults: new { controller = "Subscriptions", action = "Delete" });

 // Pages
app.MapControllerRoute(
	name: "changelog",
	pattern: "admin/changelog",
	defaults: new { controller = "Home", action = "Changelog" });

app.MapControllerRoute(
	name: "overview",
	pattern: "admin/documentation/overview",
	defaults: new { controller = "Home", action = "Overview" });

app.MapControllerRoute(
	name: "database",
	pattern: "admin/documentation/database",
	defaults: new { controller = "Home", action = "Database" });

app.MapControllerRoute(
	name: "sample-game-art",
	pattern: "admin/documentation/sample-game-art",
	defaults: new { controller = "Home", action = "SampleGameArt" });

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

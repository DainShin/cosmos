using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Identity;
using Cosmos.Models;
using Cosmos.Data;
using Microsoft.Extensions.Options;
using Cosmos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add MySQL
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string not found");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connectionString));

// Redefining Folder Structure
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Clear();
    options.ViewLocationFormats.Add("/Views/Frontend/{1}/{0}" + RazorViewEngine.ViewExtension);
    options.ViewLocationFormats.Add("/Views/Backend/{1}/{0}" + RazorViewEngine.ViewExtension);
    options.ViewLocationFormats.Add("/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
});

// Enabling Sessions
builder.Services.AddSession(options => {
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

// Adding identity service and roles
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Registering the ApplicationDbInitializer
builder.Services.AddTransient<ApplicationDbInitializer>();

// Registering Google Authentication
builder.Services.AddAuthentication().AddGoogle(options => {
	options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
	options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

// Register Cart Service as a new scoped dependency
builder.Services.AddScoped<CartService>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


var app = builder.Build();
 
/** ==================================== */
/** MIDDLEWARE                           */
/** ==================================== */
// Turn on sessions
app.UseSession();

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

// Setup Authentication and Authorization
app. UseAuthentication();
app.UseAuthorization();

// Custom Route Configurations
BackendRouteConfig.UseRoutes(app);
FrontendRouteConfig.UseRoutes(app);

app.MapRazorPages();

// Seed Starting Data
ApplicationDbInitializer.SeedData(app);

// Seed Users
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using var scope = scopeFactory.CreateScope();
// var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>();
await ApplicationDbInitializer.SeedUsers(
	scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>(),
	scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>()
);

app.Run();

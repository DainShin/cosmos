public static class FrontendRouteConfig
{
	public static void UseRoutes(IApplicationBuilder app)
	{
		app.UseEndpoints(endpoints =>
		{
			// Products
			endpoints.MapControllerRoute(
				name: "games",
				pattern: "browse/games",
				defaults: new { controller = "Products", action = "Index" });

			// Pages
			endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Pages}/{action=Index}/{id?}");

			endpoints.MapControllerRoute(
				name: "brief",
				pattern: "brief",
				defaults: new { controller = "Pages", action = "Brief" });

		});
	}
}
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
				defaults: new { controller = "CustomerGames", action = "Index" });

			// Products
			endpoints.MapControllerRoute(
				name: "cart",
				pattern: "cart",
				defaults: new { controller = "Carts", action = "Index" });


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
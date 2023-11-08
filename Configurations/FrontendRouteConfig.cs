public static class FrontendRouteConfig
{
	public static void UseRoutes(IApplicationBuilder app)
	{
		app.UseEndpoints(endpoints =>
		{
			// Games
			endpoints.MapControllerRoute(
				name: "games",
				pattern: "browse/games",
				defaults: new { controller = "CustomerGames", action = "Index" });
			
			endpoints.MapControllerRoute(
				name: "games",
				pattern: "browse/games/details",
				defaults: new { controller = "CustomerGames", action = "Details" });

			endpoints.MapControllerRoute(
				name: "games",
				pattern: "browse/games/filtered",
				defaults: new { controller = "CustomerGames", action = "GetFilteredGames" });


			// Cart
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

			endpoints.MapControllerRoute(
				name: "games",
				pattern: "games",
				defaults: new { controller = "Pages", action = "Games" });

			endpoints.MapControllerRoute(
				name: "membership",
				pattern: "membership",
				defaults: new { controller = "Pages", action = "Membership" });

			endpoints.MapControllerRoute(
				name: "download",
				pattern: "download",
				defaults: new { controller = "Pages", action = "Download" });

		});
	}
}
public static class BackendRouteConfig
{
	public static void UseRoutes(IApplicationBuilder app)
	{
		app.UseEndpoints(endpoints =>
		{
			// Games
			endpoints.MapControllerRoute(
				name: "games",
				pattern: "admin/games",
				defaults: new { controller = "Games", action = "Index" });

			endpoints.MapControllerRoute(
				name: "games",
				pattern: "admin/games/create",
				defaults: new { controller = "Games", action = "Create" });

			// Genres
			endpoints.MapControllerRoute(
				name: "genres",
				pattern: "admin/genres",
				defaults: new { controller = "Genres", action = "Index" });

			endpoints.MapControllerRoute(
				name: "genres",
				pattern: "admin/genres/create",
				defaults: new { controller = "Genres", action = "Create" });

			endpoints.MapControllerRoute(
				name: "genres",
				pattern: "admin/genres/edit",
				defaults: new { controller = "Genres", action = "Edit" });

			endpoints.MapControllerRoute(
				name: "genres",
				pattern: "admin/genres/details",
				defaults: new { controller = "Genres", action = "Details" });

			endpoints.MapControllerRoute(
				name: "genres",
				pattern: "admin/genres/delete",
				defaults: new { controller = "Genres", action = "Delete" });

			// Modes
			endpoints.MapControllerRoute(
				name: "modes",
				pattern: "admin/modes",
				defaults: new { controller = "Modes", action = "Index" });

			endpoints.MapControllerRoute(
				name: "modes",
				pattern: "admin/modes/create",
				defaults: new { controller = "Modes", action = "Create" });

			endpoints.MapControllerRoute(
				name: "modes",
				pattern: "admin/modes/edit",
				defaults: new { controller = "Modes", action = "Edit" });

			endpoints.MapControllerRoute(
				name: "modes",
				pattern: "admin/modes/details",
				defaults: new { controller = "Modes", action = "Details" });

			endpoints.MapControllerRoute(
				name: "modes",
				pattern: "admin/modes/delete",
				defaults: new { controller = "Modes", action = "Delete" });

			// Developers
			endpoints.MapControllerRoute(
				name: "developers",
				pattern: "admin/developers",
				defaults: new { controller = "Developers", action = "Index" });

			endpoints.MapControllerRoute(
				name: "developers",
				pattern: "admin/developers/create",
				defaults: new { controller = "Developers", action = "Create" });

			endpoints.MapControllerRoute(
				name: "developers",
				pattern: "admin/developers/edit",
				defaults: new { controller = "Developers", action = "Edit" });

			endpoints.MapControllerRoute(
				name: "developers",
				pattern: "admin/developers/details",
				defaults: new { controller = "Developers", action = "Details" });

			endpoints.MapControllerRoute(
				name: "developers",
				pattern: "admin/developers/delete",
				defaults: new { controller = "Developers", action = "Delete" });

			// Publishers
			endpoints.MapControllerRoute(
				name: "publishers",
				pattern: "admin/publishers",
				defaults: new { controller = "Publishers", action = "Index" });

			endpoints.MapControllerRoute(
				name: "publishers",
				pattern: "admin/publishers/create",
				defaults: new { controller = "Publishers", action = "Create" });

			endpoints.MapControllerRoute(
				name: "publishers",
				pattern: "admin/publishers/edit",
				defaults: new { controller = "Publishers", action = "Edit" });

			endpoints.MapControllerRoute(
				name: "publishers",
				pattern: "admin/publishers/details",
				defaults: new { controller = "Publishers", action = "Details" });

			endpoints.MapControllerRoute(
				name: "publishers",
				pattern: "admin/publishers/delete",
				defaults: new { controller = "Publishers", action = "Delete" });

			// Subscriptions
			endpoints.MapControllerRoute(
				name: "subscriptions",
				pattern: "admin/subscriptions",
				defaults: new { controller = "Subscriptions", action = "Index" });

			endpoints.MapControllerRoute(
				name: "subscriptions",
				pattern: "admin/subscriptions/create",
				defaults: new { controller = "Subscriptions", action = "Create" });

			endpoints.MapControllerRoute(
				name: "subscriptions",
				pattern: "admin/subscriptions/edit",
				defaults: new { controller = "Subscriptions", action = "Edit" });

			endpoints.MapControllerRoute(
				name: "subscriptions",
				pattern: "admin/subscriptions/details",
				defaults: new { controller = "Subscriptions", action = "Details" });

			endpoints.MapControllerRoute(
				name: "subscriptions",
				pattern: "admin/subscriptions/delete",
				defaults: new { controller = "Subscriptions", action = "Delete" });

			// Pages
			endpoints.MapControllerRoute(
				name: "changelog",
				pattern: "admin/changelog",
				defaults: new { controller = "Documentation", action = "Changelog" });

			endpoints.MapControllerRoute(
				name: "overview",
				pattern: "admin/documentation/overview",
				defaults: new { controller = "Documentation", action = "Overview" });

			endpoints.MapControllerRoute(
				name: "database",
				pattern: "admin/documentation/database",
				defaults: new { controller = "Documentation", action = "Database" });

			endpoints.MapControllerRoute(
				name: "sample-game-art",
				pattern: "admin/documentation/sample-game-art",
				defaults: new { controller = "Documentation", action = "SampleGameArt" });

			endpoints.MapControllerRoute(
				name: "how-to-add-game",
				pattern: "admin/documentation/how-to-add-game",
				defaults: new { controller = "Documentation", action = "HowToAddGame" });
		});
	}
}
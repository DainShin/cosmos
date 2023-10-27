public static class FrontendRouteConfig
{
	public static void UseRoutes(IApplicationBuilder app)
	{
		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllerRoute(
					name: "brief",
					pattern: "brief",
					defaults: new { controller = "Pages", action = "Brief" });

			endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Pages}/{action=Index}/{id?}");
		});
	}
}
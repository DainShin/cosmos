using Microsoft.AspNetCore.Mvc;
using Cosmos.Models;

namespace Cosmos.Components.ViewComponents
{
	public class AdminNavigationMenuViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var adminMenuItems = new List<AdminMenuItem>
			{
				new AdminMenuItem { Controller = "Games", Action = "Index", Label = "Games", Icon = "#joystick"},
				new AdminMenuItem { Controller = "Genres", Action = "Index", Label = "Genres", Icon = "#tags"},
				new AdminMenuItem { Controller = "Modes", Action = "Index", Label = "Modes", Icon="#layout-text-sidebar"},
				new AdminMenuItem { Controller = "Subscriptions", Action = "Index", Label = "Subscriptions", Icon = "#calendar-check"},
				new AdminMenuItem { Controller = "Developers", Action = "Index", Label = "Developers", Icon = "#braces"},
				new AdminMenuItem { Controller = "Publishers", Action = "Index", Label = "Publishers", Icon = "#book"},
			};

			return View(adminMenuItems);
		}
	}
}
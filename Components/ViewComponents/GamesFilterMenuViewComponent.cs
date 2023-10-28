using Microsoft.AspNetCore.Mvc;
using Cosmos.Models;

namespace Cosmos.Components.ViewComponents
{
	public class GamesFilterMenuViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var filterMenuItems = new List<FilterMenuItem>
			{
				
				new FilterMenuItem { 
					Title = "Subscription Tiers",
					SubMenuItems = new List<FilterSubMenuItem>
					{
						new FilterSubMenuItem { Category = "Products", Value = "Free", Label = "Free" },
						new FilterSubMenuItem { Category = "Products", Value = "Advanced", Label = "Advanced" },
						new FilterSubMenuItem { Category = "Products", Value = "Ultimate", Label = "Ultimate" },
					}
				},
				new FilterMenuItem { 
					Title = "Genres",
					SubMenuItems = new List<FilterSubMenuItem>
					{
						new FilterSubMenuItem { Controller = "Products", Action = "ActionGenre", Label = "Action" },
						new FilterSubMenuItem { Controller = "Products", Action = "Adventure", Label = "Adventure" },
						new FilterSubMenuItem { Controller = "Products", Action = "RolePlaying", Label = "Role-playing" },
						new FilterSubMenuItem { Controller = "Products", Action = "Strategy", Label = "Strategy" },
						new FilterSubMenuItem { Controller = "Products", Action = "Racing", Label = "Racing" },
						new FilterSubMenuItem { Controller = "Products", Action = "Shooter", Label = "Shooter" },
						new FilterSubMenuItem { Controller = "Products", Action = "Sports", Label = "Sports" },
						new FilterSubMenuItem { Controller = "Products", Action = "Puzzle", Label = "Puzzle" },
						new FilterSubMenuItem { Controller = "Products", Action = "Platformer", Label = "Platformer" },
						new FilterSubMenuItem { Controller = "Products", Action = "Simulation", Label = "Simulation" },
					}
				},
				new FilterMenuItem { 
					Title = "Game Modes",
					SubMenuItems = new List<FilterSubMenuItem>
					{
						new FilterSubMenuItem { Controller = "Products", Action = "SinglePlayer", Label = "Single Player" },
						new FilterSubMenuItem { Controller = "Products", Action = "Multiplayer", Label = "Multiplayer" },
						new FilterSubMenuItem { Controller = "Products", Action = "Coop", Label = "Co-op" },
						new FilterSubMenuItem { Controller = "Products", Action = "MassivelyMultiplayerOnline", Label = "Massively Multiplayer Online" },
					}
				},
				
			};

			return View(filterMenuItems);
		}
	}
}
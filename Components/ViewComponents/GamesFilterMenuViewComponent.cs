using Microsoft.AspNetCore.Mvc;
using Cosmos.Models;

namespace Cosmos.Components.ViewComponents
{
	public class GamesFilterMenuViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(Dictionary<string, string> currentFilters)
		{
			var filterMenuItems = new List<GameFilterMenuItem>
			{
				new GameFilterMenuItem {
					Title = "Subscription Tiers",
					SubMenuItems = new List<GameFilterSubMenuItem>
					{
						new GameFilterSubMenuItem { Category = "subscription", Value = "Free", Label = "Free" },
						new GameFilterSubMenuItem { Category = "subscription", Value = "Advanced", Label = "Advanced" },
						new GameFilterSubMenuItem { Category = "subscription", Value = "Ultimate", Label = "Ultimate" },
					}
				},
				new GameFilterMenuItem {
					Title = "Genres",
					SubMenuItems = new List<GameFilterSubMenuItem>
					{
						new GameFilterSubMenuItem { Category = "genre", Value = "Action", Label = "Action" },
						new GameFilterSubMenuItem { Category = "genre", Value = "Adventure", Label = "Adventure" },
						new GameFilterSubMenuItem { Category = "genre", Value = "Role-playing", Label = "Role-playing" },
						new GameFilterSubMenuItem { Category = "genre", Value = "Strategy", Label = "Strategy" },
						new GameFilterSubMenuItem { Category = "genre", Value = "Racing", Label = "Racing" },
						new GameFilterSubMenuItem { Category = "genre", Value = "Shooter", Label = "Shooter" },
						new GameFilterSubMenuItem { Category = "genre", Value = "Sports", Label = "Sports" },
						new GameFilterSubMenuItem { Category = "genre", Value = "Puzzle", Label = "Puzzle" },
						new GameFilterSubMenuItem { Category = "genre", Value = "Platformer", Label = "Platformer" },
						new GameFilterSubMenuItem { Category = "genre", Value = "Simulation", Label = "Simulation" },
					}
				},
				new GameFilterMenuItem {
					Title = "Game Modes",
					SubMenuItems = new List<GameFilterSubMenuItem>
					{
						new GameFilterSubMenuItem { Category = "mode", Value = "Single Player", Label = "Single Player" },
						new GameFilterSubMenuItem { Category = "mode", Value = "Multiplayer", Label = "Multiplayer" },
						new GameFilterSubMenuItem { Category = "mode", Value = "Co-op", Label = "Co-op" },
						new GameFilterSubMenuItem { Category = "mode", Value = "Massively Multiplayer Online", Label = "MMO" },
					}
				},

			};

			// Check the current filters and set IsSelected accordingly
			foreach (var item in filterMenuItems.SelectMany(menu => menu.SubMenuItems))
			{
				if (currentFilters.TryGetValue(item.Category, out var value))
				{
					item.IsSelected = value.Split(",").Contains(item.Value);
				}
			}

			return View(filterMenuItems);
		}
	}
}
using Microsoft.AspNetCore.Mvc;
using Cosmos.Models;

namespace Cosmos.Components.ViewComponents
{
	public class DocumentationNavigationMenuViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var documentationMenuItems = new List<SidebarMenuItem>
			{
				new SidebarMenuItem { 
					Title = "Getting Started",
					SubMenuItems = new List<SidebarSubMenuItem>
					{
						new SidebarSubMenuItem { Controller = "Documentation", Action = "Overview", Label = "Overview" },
						new SidebarSubMenuItem { Controller = "Documentation", Action = "Database", Label = "Database" },
						new SidebarSubMenuItem { Controller = "Documentation", Action = "SampleGameArt", Label = "Sample Game Art" },
					}
				},
				new SidebarMenuItem { 
					Title = "Core Features",
					SubMenuItems = new List<SidebarSubMenuItem>
					{
						new SidebarSubMenuItem { Controller = "Documentation", Action = "HowToAddGame", Label = "How to Add a Game" },
					}
				},
				
			};

			return View(documentationMenuItems);
		}
	}
}
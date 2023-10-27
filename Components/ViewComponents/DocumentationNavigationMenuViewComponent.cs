using Microsoft.AspNetCore.Mvc;
using Cosmos.Models;

namespace Cosmos.Components.ViewComponents
{
	public class DocumentationNavigationMenuViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var documentationMenuItems = new List<DocumentationMenuItem>
			{
				new DocumentationMenuItem { 
					Title = "Getting Started",
					SubMenuItems = new List<DocumentationSubMenuItem>
					{
						new DocumentationSubMenuItem { Controller = "Documentation", Action = "Overview", Label = "Overview" },
						new DocumentationSubMenuItem { Controller = "Documentation", Action = "Database", Label = "Database" },
						new DocumentationSubMenuItem { Controller = "Documentation", Action = "SampleGameArt", Label = "Sample Game Art" },
					}
				},
				new DocumentationMenuItem { 
					Title = "Core Features",
					SubMenuItems = new List<DocumentationSubMenuItem>
					{
						new DocumentationSubMenuItem { Controller = "Documentation", Action = "HowToAddGame", Label = "How to Add a Game" },
					}
				},
				
			};

			return View(documentationMenuItems);
		}
	}
}
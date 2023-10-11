using Microsoft.AspNetCore.Mvc;
using Cosmos.Models;
using System.Collections.Generic;

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
						new DocumentationSubMenuItem { Controller = "Home", Action = "Overview", Label = "Overview" },
						new DocumentationSubMenuItem { Controller = "Home", Action = "Database", Label = "Database" },
						new DocumentationSubMenuItem { Controller = "Home", Action = "SampleGameArt", Label = "Sample Game Art" },
					}
				},
				
			};

			return View(documentationMenuItems);
		}
	}
}
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
				// new DocumentationMenuItem { Controller = "Home", Action = "Overview", Label = "Overview"},
				// new DocumentationMenuItem { Controller = "Home", Action = "Database", Label = "Database"},
				// new DocumentationMenuItem { Controller = "Home", Action = "SampleGameArt", Label = "Sample Game Art"},
			};

			return View(documentationMenuItems);
		}
	}
}
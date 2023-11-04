using Microsoft.AspNetCore.Mvc;
using Cosmos.Models;

namespace Cosmos.Components.ViewComponents
{
    public class MainNavigationMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var mainMenuItem = new List<MainMenuItem>
            {
                  new MainMenuItem {Controller = "Pages", Action = "Index", Label = "Home"},  
                  new MainMenuItem {Controller = "Pages", Action = "Brief", Label = "Brief"},  
                  new MainMenuItem {Controller = "CustomerGames", Action = "Index", Label = "Games"},  
                  new MainMenuItem {Controller = "Pages", Action = "Index", Label = "Membership"},  
                  new MainMenuItem {Controller = "Pages", Action = "Index", Label = "Download"},  
                  new MainMenuItem {Controller = "Pages", Action = "Index", Label = "How to Play"},  
            };
            
            return View(mainMenuItem);
        }
    }
}

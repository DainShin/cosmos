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
                  new MainMenuItem {Controller = "Home", Action = "Index", Label = "Home"},  
                  new MainMenuItem {Controller = "Home", Action = "Brief", Label = "Brief"},  
                  new MainMenuItem {Controller = "Home", Action = "Index", Label = "Membership"},  
                  new MainMenuItem {Controller = "Home", Action = "Index", Label = "Download"},  
                  new MainMenuItem {Controller = "Home", Action = "Index", Label = "How to Play"},  
            };
            
            return View(mainMenuItem);
        }
    }
}

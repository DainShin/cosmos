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
                  new MainMenuItem {Controller = "Pages", Action = "Index", Label = "Home", IsNew = false},  
                  new MainMenuItem {Controller = "Pages", Action = "Brief", Label = "Brief", IsNew = false},  
                  new MainMenuItem {Controller = "CustomerGames", Action = "Index", Label = "Games", IsNew = true},  
                  new MainMenuItem {Controller = "Pages", Action = "Index", Label = "Membership", IsNew = false},  
                  new MainMenuItem {Controller = "Pages", Action = "Index", Label = "Download", IsNew = false},  
                  new MainMenuItem {Controller = "Pages", Action = "Index", Label = "How to Play", IsNew = false},  
            };
            
            return View(mainMenuItem);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Cosmos.Models;

namespace Cosmos.Components.ViewComponents
{
    public class SecondaryMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var secondaryMenuItem = new List<SecondaryMenuItem>
            {
                  new SecondaryMenuItem {Controller = "Home", Action = "Index", Label = "Home"},  
                  new SecondaryMenuItem {Controller = "Home", Action = "Brief", Label = "Brief"},  
                  new SecondaryMenuItem {Controller = "Home", Action = "Index", Label = "Membership"},  
                  new SecondaryMenuItem {Controller = "Home", Action = "Index", Label = "Download"},  
                  new SecondaryMenuItem {Controller = "Home", Action = "Index", Label = "How to Play"},  
            };
            
            return View(secondaryMenuItem);
        }
    }
}

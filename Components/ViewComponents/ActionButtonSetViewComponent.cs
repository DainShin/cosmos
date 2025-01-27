using Microsoft.AspNetCore.Mvc;
using Cosmos.Models;

namespace Cosmos.Components.ViewComponents
{
    public class ActionButtonSetViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id, string controller) 
        {
            var actionButtonItems = new List<ActionButton> {
                new ActionButton {Controller = controller, Action = "Details", Id = id, Icon = "fa-solid fa-desktop", Color = "text-info"},
                new ActionButton {Controller = controller, Action = "Edit", Id = id, Icon = "fa-solid fa-pencil", Color = "text-dark"},
                new ActionButton {Controller = controller, Action = "Delete", Id = id, Icon = "fa-solid fa-trash", Color = "text-danger"},
            };

            return View(actionButtonItems);
        }
    }
}
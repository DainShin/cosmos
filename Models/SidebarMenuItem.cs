namespace Cosmos.Models
{
	public class SidebarMenuItem
	{
		public string? Title { get; set; }
		public List<SidebarSubMenuItem> SubMenuItems { get; set; } = new List<SidebarSubMenuItem>();
	}
}
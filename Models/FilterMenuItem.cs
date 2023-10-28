namespace Cosmos.Models
{
	public class FilterMenuItem
	{
		public string? Title { get; set; }
		public List<FilterSubMenuItem> SubMenuItems { get; set; } = new List<FilterSubMenuItem>();
	}
}
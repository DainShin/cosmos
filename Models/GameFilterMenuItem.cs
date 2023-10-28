namespace Cosmos.Models
{
	public class GameFilterMenuItem
	{
		public string? Title { get; set; }
		public List<GameFilterSubMenuItem> SubMenuItems { get; set; } = new List<GameFilterSubMenuItem>();
	}
}
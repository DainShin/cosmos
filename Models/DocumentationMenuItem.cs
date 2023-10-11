namespace Cosmos.Models
{
	public class DocumentationMenuItem
	{
		public string? Title { get; set; }
		public List<DocumentationSubMenuItem> SubMenuItems { get; set; } = new List<DocumentationSubMenuItem>();
	}
}
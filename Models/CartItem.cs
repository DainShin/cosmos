namespace Cosmos.Models
{
    public class CartItem
    {
        public int GameId { get; set; }
        public int Quantity { get; set; }
        public Game Game { get; set; } = new Game();
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Cosmos.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cosmos.Controllers
{
	[Authorize(Roles = "Customer")]
	public class CartsController : Controller
	{
		private readonly string _cartSessionKey;
		private readonly ApplicationDbContext _context;

		public CartsController(ApplicationDbContext context)
		{
			_cartSessionKey = "Cart";
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var cart = GetCart();

			if (cart == null)
			{
				return NotFound();
			}

			if (cart.CartItems.Count > 0)
			{
				foreach (var cartItem in cart.CartItems)
				{
					var game = await _context.Games
						.Include(g => g.Genres)
						.FirstOrDefaultAsync(g => g.Id == cartItem.GameId);

					if (game != null)
					{
						cartItem.Game = game;
					}
				}
			}

			return View(cart);
		}

		[HttpPost]
		public async Task<IActionResult> AddToCart(int gameId, int quantity)
		{
			// Getting the active cart
			var cart = GetCart();

			if (cart == null)
			{
				return NotFound();
			}

			// Checking if the item is already in the cart
			var cartItem = cart.CartItems.Find(cartItem => cartItem.GameId == gameId);

			if (cartItem == null)
			{
				var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId);

				if (game == null)
				{
					return NotFound();
				}

				cartItem = new CartItem
				{
					GameId = gameId,
					Quantity = quantity,
					Game = game
				};

				cart.CartItems.Add(cartItem);
			}

			SaveCart(cart);

			return RedirectToAction("Details", "CustomerGames", new { id = gameId });
		}

		[HttpPost]
		public async Task<IActionResult> RemoveFromCart(int gameId)
		{
			// Getting the active cart
			var cart = GetCart();

			if (cart == null)
			{
				return NotFound();
			}

			// Checking if the item is already in the cart
			var cartItem = cart.CartItems.Find(cartItem => cartItem.GameId == gameId);

			if (cartItem != null)
			{
				var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId);

				if (game == null)
				{
					return NotFound();
				}

				cart.CartItems.Remove(cartItem);
			}

			SaveCart(cart);

			return RedirectToAction("Index", "Carts");
		}

		private Cart? GetCart()
		{
			var cartJson = HttpContext.Session.GetString(_cartSessionKey);
			return cartJson == null ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartJson);
		}

		private void SaveCart(Cart cart)
		{
			var cartJson = JsonConvert.SerializeObject(cart);
			HttpContext.Session.SetString(_cartSessionKey, cartJson);
			// Updating the cart item count in the session
			HttpContext.Session.SetInt32("CartItemCount", cart.CartItems.Count);
		}

	}

}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cosmos.Models;
using Microsoft.AspNetCore.Authorization;
using Cosmos.Services;

namespace Cosmos.Controllers
{
	[Authorize(Roles = "Customer")]
	public class CartsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly CartService _cartService;

		public CartsController(ApplicationDbContext context, CartService cartService)
		{
			_context = context;
			_cartService = cartService;
		}

		public async Task<IActionResult> Index()
		{
			var cart = _cartService.GetCart();

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
			var cart = _cartService.GetCart();

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

			_cartService.SaveCart(cart);

			return RedirectToAction("Details", "CustomerGames", new { id = gameId });
		}

		[HttpPost]
		public async Task<IActionResult> RemoveFromCart(int gameId)
		{
			// Getting the active cart
			var cart = _cartService.GetCart();

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

			_cartService.SaveCart(cart);

			return RedirectToAction("Index", "Carts");
		}

	}

}


using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cosmos.Models;
using Newtonsoft.Json;

namespace Cosmos.Controllers.Frontend
{
	public class CustomerGamesController : Controller
	{
		private readonly string _cartSessionKey;
		private readonly ApplicationDbContext _context;

		public CustomerGamesController(ApplicationDbContext context)
		{
			_cartSessionKey = "Cart";
			_context = context;
		}

		// GET: Games
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Games
				.Include(g => g.Developer)
				.Include(g => g.Publisher)
				.Include(g => g.Modes)
				.Include(g => g.Genres)
				.Include(g => g.Subscriptions);

			ViewBag.Filters = null;
			return View(await applicationDbContext.ToListAsync());
		}

		// Get: Games with filters
		public async Task<IActionResult> GetFilteredGames([FromQuery(Name = "filter[subscription]")] string[] filterSubscription, [FromQuery(Name = "filter[genre]")] string[] filterGenre, [FromQuery(Name = "filter[mode]")] string[] filterMode)
		{
			var gamesQuery = _context.Games
				.Include(g => g.Developer)
				.Include(g => g.Publisher)
				.Include(g => g.Modes)
				.Include(g => g.Genres)
				.Include(g => g.Subscriptions)
				.AsQueryable();

			List<string> filterList = new List<string>();

			// Apply subscription filters
			if (filterSubscription.Length > 0)
			{
				gamesQuery = gamesQuery.Where(game => game.Subscriptions.Any(subscription => filterSubscription.Contains(subscription.Name)));
				filterList.AddRange(filterSubscription);
			}

			// Apply genre filters
			if (filterGenre.Length > 0)
			{
				gamesQuery = gamesQuery.Where(game => game.Genres.Any(genre => filterGenre.Contains(genre.Name)));
				filterList.AddRange(filterGenre);
			}

			// Apply mode filters
			if (filterMode.Length > 0)
			{
				gamesQuery = gamesQuery.Where(game => game.Modes.Any(mode => filterMode.Contains(mode.Name)));
				filterList.AddRange(filterMode);
			}

			var filteredGames = await gamesQuery.ToListAsync();


			ViewBag.Filters = filterList;
			return View("Index", filteredGames);
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Games == null)
			{
				return NotFound();
			}

			var game = await _context.Games
				.Include(g => g.Developer)
				.Include(g => g.Publisher)
				.Include(g => g.Modes)
				.Include(g => g.Genres)
				.Include(g => g.Subscriptions)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (game == null)
			{
				return NotFound();
			}

			var cart = GetCart();
			bool isInCart = false;
			if (cart != null)
			{
				isInCart = cart.CartItems.Any(ci => ci.GameId == id);
			}
			// Pass the isInCart flag to the view using ViewBag or ViewData
			ViewBag.IsInCart = isInCart;

			return View(game);
		}

		private Cart? GetCart()
		{
			var cartJson = HttpContext.Session.GetString(_cartSessionKey);
			return cartJson == null ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartJson);
		}
	}
}

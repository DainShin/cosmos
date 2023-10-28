
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cosmos.Models;

namespace Cosmos.Controllers.Frontend
{
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ProductsController(ApplicationDbContext context)
		{
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
			return View(await applicationDbContext.ToListAsync());
		}
	}
}

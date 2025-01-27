using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Cosmos.Models;

namespace Cosmos.Controllers
{
	[Authorize(Roles = "Admin")]
	public class DevelopersController : Controller
	{
		private readonly ApplicationDbContext _context;

		public DevelopersController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Developers
		public async Task<IActionResult> Index()
		{
			return _context.Developers != null ?
						View(await _context.Developers.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.Developers'  is null.");
		}

		// GET: Developers/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Developers == null)
			{
				return NotFound();
			}

			var developer = await _context.Developers
				.Include(developer => developer.Games)
					.ThenInclude(game => game.Genres)
				
				.Include(developer => developer.Games)
					.ThenInclude(game => game.Publisher)
				
				.Include(developer => developer.Games)
					.ThenInclude(game => game.Modes)
				
				.Include(developer => developer.Games)
					.ThenInclude(game => game.Subscriptions)

				.Include(developer => developer.Games.OrderBy(game => game.Name))
				
				.FirstOrDefaultAsync(m => m.Id == id);

			if (developer == null)
			{
				return NotFound();
			}

			return View(developer);
		}

		// GET: Developers/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Developers/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,CreatedAt")] Developer developer)
		{
			if (ModelState.IsValid)
			{
				_context.Add(developer);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(developer);
		}

		// GET: Developers/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Developers == null)
			{
				return NotFound();
			}

			var developer = await _context.Developers.FindAsync(id);
			if (developer == null)
			{
				return NotFound();
			}
			return View(developer);
		}

		// POST: Developers/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedAt")] Developer developer)
		{
			if (id != developer.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(developer);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!DeveloperExists(developer.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(developer);
		}

		// GET: Developers/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Developers == null)
			{
				return NotFound();
			}

			var developer = await _context.Developers
				.FirstOrDefaultAsync(m => m.Id == id);
			if (developer == null)
			{
				return NotFound();
			}

			return View(developer);
		}

		// POST: Developers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Developers == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Developers'  is null.");
			}
			var developer = await _context.Developers.FindAsync(id);
			if (developer != null)
			{
				_context.Developers.Remove(developer);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool DeveloperExists(int id)
		{
			return (_context.Developers?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}

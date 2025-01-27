using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Cosmos.Models;

namespace Cosmos.Controllers
{
	[Authorize(Roles = "Admin")]
	public class SubscriptionsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public SubscriptionsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Subscriptions
		public async Task<IActionResult> Index()
		{
			return _context.Subscriptions != null ?
						View(await _context.Subscriptions.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.Subscriptions'  is null.");
		}

		// GET: Subscriptions/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Subscriptions == null)
			{
				return NotFound();
			}

			var subscription = await _context.Subscriptions
				.Include(subscription => subscription.Games)
					.ThenInclude(game => game.Developer)

				.Include(subscription => subscription.Games)
					.ThenInclude(game => game.Publisher)

				.Include(subscription => subscription.Games)
					.ThenInclude(game => game.Modes)

				.Include(subscription => subscription.Games)
					.ThenInclude(game => game.Genres)

				.Include(subscription => subscription.Games.OrderBy(game => game.Name))

				.FirstOrDefaultAsync(m => m.Id == id);

			if (subscription == null)
			{
				return NotFound();
			}

			return View(subscription);
		}

		// GET: Subscriptions/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Subscriptions/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Price,CreatedAt")] Subscription subscription)
		{
			if (ModelState.IsValid)
			{
				_context.Add(subscription);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(subscription);
		}

		// GET: Subscriptions/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Subscriptions == null)
			{
				return NotFound();
			}

			var subscription = await _context.Subscriptions.FindAsync(id);
			if (subscription == null)
			{
				return NotFound();
			}
			return View(subscription);
		}

		// POST: Subscriptions/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CreatedAt")] Subscription subscription)
		{
			if (id != subscription.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(subscription);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!SubscriptionExists(subscription.Id))
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
			return View(subscription);
		}

		// GET: Subscriptions/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Subscriptions == null)
			{
				return NotFound();
			}

			var subscription = await _context.Subscriptions
				 .Include(s => s.Games.OrderBy(game => game.Name))
				.FirstOrDefaultAsync(m => m.Id == id);
			if (subscription == null)
			{
				return NotFound();
			}

			return View(subscription);
		}

		// POST: Subscriptions/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Subscriptions == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Subscriptions'  is null.");
			}
			var subscription = await _context.Subscriptions.FindAsync(id);
			if (subscription != null)
			{
				_context.Subscriptions.Remove(subscription);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool SubscriptionExists(int id)
		{
			return (_context.Subscriptions?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}

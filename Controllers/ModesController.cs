using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cosmos.Models;

namespace Cosmos.Controllers
{
	public class ModesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ModesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Modes
		public async Task<IActionResult> Index()
		{
			return _context.Modes != null ?
						View(await _context.Modes.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.Modes'  is null.");
		}

		// GET: Modes/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Modes == null)
			{
				return NotFound();
			}

			var mode = await _context.Modes
				.Include(mode => mode.Games.OrderBy(game => game.Name))
				.FirstOrDefaultAsync(m => m.Id == id);
			if (mode == null)
			{
				return NotFound();
			}

			return View(mode);
		}

		// GET: Modes/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Modes/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,CreatedAt")] Mode mode)
		{
			if (ModelState.IsValid)
			{
				_context.Add(mode);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(mode);
		}

		// GET: Modes/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Modes == null)
			{
				return NotFound();
			}

			var mode = await _context.Modes.FindAsync(id);
			if (mode == null)
			{
				return NotFound();
			}
			return View(mode);
		}

		// POST: Modes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedAt")] Mode mode)
		{
			if (id != mode.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(mode);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ModeExists(mode.Id))
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
			return View(mode);
		}

		// GET: Modes/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Modes == null)
			{
				return NotFound();
			}

			var mode = await _context.Modes
				.FirstOrDefaultAsync(m => m.Id == id);
			if (mode == null)
			{
				return NotFound();
			}

			return View(mode);
		}

		// POST: Modes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Modes == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Modes'  is null.");
			}
			var mode = await _context.Modes.FindAsync(id);
			if (mode != null)
			{
				_context.Modes.Remove(mode);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ModeExists(int id)
		{
			return (_context.Modes?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}

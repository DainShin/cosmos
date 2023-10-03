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
	public class GamesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public GamesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Games
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Games
				.Include(g => g.Developer)
				.Include(g => g.Publisher);
			// .Include(g => g.Modes)
			// .Include(g => g.Genres)
			// .Include(g => g.Subscriptions);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Games/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Games == null)
			{
				return NotFound();
			}

			var game = await _context.Games
				.Include(g => g.Developer)
				// .Include(g => g.Publisher)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (game == null)
			{
				return NotFound();
			}

			return View(game);
		}

		// GET: Games/Create
		public IActionResult Create()
		{
			// ViewBag.Modes = new MultiSelectList(_context.Modes, "Id", "Name");
			// ViewBag.Genres = new MultiSelectList(_context.Genres, "Id", "Name");
			// ViewBag.Subscriptions = new MultiSelectList(_context.Subscriptions, "Id", "Name");
			ViewData["DeveloperId"] = new SelectList(_context.Developers, "Id", "Name");
			ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name");
			return View();
		}

		// POST: Games/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		// public async Task<IActionResult> Create([Bind("Id,Name,Description,Image,ReleaseDate,Enabled,CreatedAt,DeveloperId,PublisherId")] Game game)
		public async Task<IActionResult> Create([Bind("Id,Name,Description,ReleaseDate,DeveloperId,PublisherId")] Game game, IFormFile gameArt)
		{
			if (ModelState.IsValid)
			{
				// if (selectedModes != null && selectedModes.Any())
				// {
				// 	// Getting the selected modes from the database
				// 	var modesToAttach = _context.Modes.Where(m => selectedModes.Contains(m.Id)).ToList();
				// 	game.Modes = modesToAttach;
				// }

				// if (selectedGenres != null && selectedGenres.Any())
				// {
				// 	// Getting the selected genres from the database
				// 	var genresToAttach = _context.Genres.Where(g => selectedGenres.Contains(g.Id)).ToList();
				// 	game.Genres = genresToAttach;
				// }

				// if (selectedSubscriptions != null && selectedSubscriptions.Any())
				// {
				// 	// Getting the selected subscriptions from the database
				// 	var subscriptionsToAttach = _context.Subscriptions.Where(s => selectedSubscriptions.Contains(s.Id)).ToList();
				// 	game.Subscriptions = subscriptionsToAttach;
				// }

				// Handle game image upload
				if (gameArt != null && gameArt.Length > 0)
				{
					// Use the game's Name (or another unique identifier) as a prefix for the filename.
					var formattedGameName = game.Name.ToLower().Replace(' ', '-');
					var fileName = $"{formattedGameName}_{Path.GetFileName(gameArt.FileName)}";
					var filePath = Path.Combine("Data/Uploads/GameArt/", fileName); // replace "path_to_your_directory" with your actual path

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await gameArt.CopyToAsync(stream);
					}

					game.Image = filePath; // Store the path to the game image in the database
				}

				_context.Add(game);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			// PopulateViewBags(game, selectedModes, selectedGenres, selectedSubscriptions, true);
			// ViewBag.Modes = new MultiSelectList(_context.Modes, "Id", "Name", selectedModes);
			// ViewBag.Genres = new MultiSelectList(_context.Genres, "Id", "Name", selectedGenres);
			// ViewBag.Subscriptions = new MultiSelectList(_context.Subscriptions, "Id", "Name", selectedSubscriptions);
			ViewData["DeveloperId"] = new SelectList(_context.Developers, "Id", "Name", game.DeveloperId);
			ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", game.PublisherId);
			return View(game);
		}

		// GET: Games/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Games == null)
			{
				return NotFound();
			}

			var game = await _context.Games.FindAsync(id);
			if (game == null)
			{
				return NotFound();
			}
			ViewData["DeveloperId"] = new SelectList(_context.Developers, "Id", "Name", game.DeveloperId);
			ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", game.PublisherId);
			return View(game);
		}

		// POST: Games/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Image,ReleaseDate,Enabled,CreatedAt,DeveloperId,PublisherId")] Game game)
		{
			if (id != game.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(game);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!GameExists(game.Id))
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
			ViewData["DeveloperId"] = new SelectList(_context.Developers, "Id", "Name", game.DeveloperId);
			ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", game.PublisherId);
			return View(game);
		}

		// GET: Games/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Games == null)
			{
				return NotFound();
			}

			var game = await _context.Games
				.Include(g => g.Developer)
				.Include(g => g.Publisher)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (game == null)
			{
				return NotFound();
			}

			return View(game);
		}

		// POST: Games/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Games == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Games'  is null.");
			}
			var game = await _context.Games.FindAsync(id);
			if (game != null)
			{
				_context.Games.Remove(game);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool GameExists(int id)
		{
			return (_context.Games?.Any(e => e.Id == id)).GetValueOrDefault();
		}

		private void PopulateViewBags(Game game, List<int> selectedModes, List<int> selectedGenres, List<int> selectedSubscriptions, Boolean repopulate = false)
		{
			// ViewBag.Modes = new MultiSelectList(_context.Modes, "Id", "Name", selectedModes);
			// ViewBag.Genres = new MultiSelectList(_context.Genres, "Id", "Name", selectedGenres);
			// ViewBag.Subscriptions = new MultiSelectList(_context.Subscriptions, "Id", "Name", selectedSubscriptions);
			ViewData["DeveloperId"] = new SelectList(_context.Developers, "Id", "Name", game.DeveloperId);
			ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name", game.PublisherId);
		}
	}
}

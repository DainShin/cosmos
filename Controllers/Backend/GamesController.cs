using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Cosmos.Models;

namespace Cosmos.Controllers
{
	[Authorize(Roles = "Admin")]
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
				.Include(g => g.Publisher)
				.Include(g => g.Modes)
				.Include(g => g.Genres)
				.Include(g => g.Subscriptions);
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
				.Include(g => g.Publisher)
				.Include(g => g.Modes)
				.Include(g => g.Genres)
				.Include(g => g.Subscriptions)
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
			PopulateViewBags();
			return View();
		}

		// POST: Games/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		// public async Task<IActionResult> Create([Bind("Id,Name,Description,ImagePath,ReleaseDate,Enabled,CreatedAt,DeveloperId,PublisherId")] Game game)
		public async Task<IActionResult> Create([Bind("Id,Name,Description,ReleaseDate,DeveloperId,PublisherId,Price")] Game game, IFormFile gameArt, List<int> selectedModes, List<int> selectedGenres, List<int> selectedSubscriptions)
		{
			if (ModelState.IsValid)
			{
				if (selectedModes != null && selectedModes.Any())
				{
					// Getting the selected modes from the database
					var modesToAttach = _context.Modes.Where(m => selectedModes.Contains(m.Id)).ToList();
					game.Modes = modesToAttach;
				}

				if (selectedGenres != null && selectedGenres.Any())
				{
					// Getting the selected genres from the database
					var genresToAttach = _context.Genres.Where(g => selectedGenres.Contains(g.Id)).ToList();
					game.Genres = genresToAttach;
				}

				if (selectedSubscriptions != null && selectedSubscriptions.Any())
				{
					// Getting the selected subscriptions from the database
					var subscriptionsToAttach = _context.Subscriptions.Where(s => selectedSubscriptions.Contains(s.Id)).ToList();
					game.Subscriptions = subscriptionsToAttach;
				}

				// Handle game imagePath upload
				if (gameArt != null && gameArt.Length > 0)
				{
					UploadGameArt(game, gameArt);
				}

				_context.Add(game);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			RepopulateViewBags(game, selectedModes, selectedGenres, selectedSubscriptions);
			return View(game);
		}

		// GET: Games/Edit/5
		public async Task<IActionResult> Edit(int? id)
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
				.FirstOrDefaultAsync(g => g.Id == id);

			if (game == null)
			{
				return NotFound();
			}

			RepopulateViewBags(game, game.Modes.Select(m => m.Id).ToList(), game.Genres.Select(g => g.Id).ToList(), game.Subscriptions.Select(s => s.Id).ToList());
			return View(game);
		}

		// POST: Games/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImagePath,ReleaseDate,Enabled,CreatedAt,DeveloperId,PublisherId,Price")] Game game, IFormFile? gameArt, List<int> selectedModes, List<int> selectedGenres, List<int> selectedSubscriptions)
		{
			// Load the existing game entity from the database
			var existingGame = await _context.Games
				.Include(g => g.Modes)
				.Include(g => g.Genres)
				.Include(g => g.Subscriptions)
				.SingleOrDefaultAsync(g => g.Id == id);

			if(existingGame == null)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					// Handle game imagePath upload
					if (gameArt != null && gameArt.Length > 0)
					{
						DeleteGameArt(existingGame);
						UploadGameArt(existingGame, gameArt);
					}

					// Clear the existing modes
					existingGame.Modes.Clear();

					// Clear the existing genres
					existingGame.Genres.Clear();

					// Clear the existing subscriptions
					existingGame.Subscriptions.Clear();

					// Add the new modes
					var modesToAttach = _context.Modes.Where(m => selectedModes.Contains(m.Id)).ToList();
					existingGame.Modes = modesToAttach;

					// Add the new genres
					var genresToAttach = _context.Genres.Where(g => selectedGenres.Contains(g.Id)).ToList();
					existingGame.Genres = genresToAttach;

					// Add the new subscriptions
					var subscriptionsToAttach = _context.Subscriptions.Where(s => selectedSubscriptions.Contains(s.Id)).ToList();
					existingGame.Subscriptions = subscriptionsToAttach;

					// Update the existing game entity with the new values
					existingGame.Name = game.Name;
					existingGame.Description = game.Description;
					existingGame.ReleaseDate = game.ReleaseDate;
					existingGame.DeveloperId = game.DeveloperId;
					existingGame.PublisherId = game.PublisherId;
					existingGame.Price = game.Price;

					_context.Update(existingGame);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!GameExists(existingGame.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Details), new { id = existingGame.Id });
			}
			RepopulateViewBags(existingGame, selectedModes, selectedGenres, selectedSubscriptions);
			return View(existingGame);
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
				.Include(g => g.Modes)
				.Include(g => g.Genres)
				.Include(g => g.Subscriptions)
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
				DeleteGameArt(game);
				_context.Games.Remove(game);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool GameExists(int id)
		{
			return (_context.Games?.Any(e => e.Id == id)).GetValueOrDefault();
		}

		/**
		 * Helper methods for populating the view bags.
		 * Populate the view bags with the modes, genres, subscriptions, developers, and publishers.
		 */
		private void PopulateViewBags()
		{
			ViewBag.Modes = new MultiSelectList(_context.Modes, "Id", "Name");
			ViewBag.Genres = new MultiSelectList(_context.Genres, "Id", "Name");
			ViewBag.Subscriptions = new MultiSelectList(_context.Subscriptions, "Id", "Name");
			ViewBag.DeveloperId = new SelectList(_context.Developers, "Id", "Name");
			ViewBag.PublisherId = new SelectList(_context.Publishers, "Id", "Name");
		}

		/**
		 * Helper methods for repopulating the view bags.
		 * Populate the view bags with previously entered modes, genres, subscriptions, developers, and publishers.
		 */
		private void RepopulateViewBags(Game game, List<int> selectedModes, List<int> selectedGenres, List<int> selectedSubscriptions)
		{
			ViewBag.Modes = new MultiSelectList(_context.Modes, "Id", "Name", selectedModes);
			ViewBag.Genres = new MultiSelectList(_context.Genres, "Id", "Name", selectedGenres);
			ViewBag.Subscriptions = new MultiSelectList(_context.Subscriptions, "Id", "Name", selectedSubscriptions);
			ViewBag.DeveloperId = new SelectList(_context.Developers, "Id", "Name", game.DeveloperId);
			ViewBag.PublisherId = new SelectList(_context.Publishers, "Id", "Name", game.PublisherId);
		}

		/**
		 * Helper methods for uploading game art.
		 */
		private async void UploadGameArt(Game game, IFormFile gameArt)
		{
			// Handle game imagePath upload
			if (gameArt != null && gameArt.Length > 0)
			{
				// Use the game's Name (or another unique identifier) as a prefix for the filename.
				var formattedGameName = game.Name.ToLower().Replace(' ', '-') + "-" + DateTimeOffset.UtcNow.ToUnixTimeSeconds();

				// Checks if file path exists, if not, create it.
				var wwwRootPath = "wwwroot/";
				var directoryPath = "uploads/game-art/";
				if (!Directory.Exists(wwwRootPath + directoryPath))
				{
					Directory.CreateDirectory(wwwRootPath + directoryPath);
				}

				// Combine the directory path and the formatted game name to create the full file path.
				var filePath = Path.Combine(directoryPath, formattedGameName + Path.GetExtension(gameArt.FileName));

				// Copy the file to the file path.
				using (var stream = new FileStream(wwwRootPath + filePath, FileMode.Create))
				{
					await gameArt.CopyToAsync(stream);
				}

				// Store the path to the game image in the database
				game.ImagePath = filePath;
			}
		}

		/**
		* Helper methods for deleting game art.
		*/
		private static void DeleteGameArt(Game game)
		{
			// Gets absolute path to the game image.
			var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", game.ImagePath);

			if (System.IO.File.Exists(imagePath) && !imagePath.Contains("sample-game-art"))
			{
				// Deletes the game image.
				System.IO.File.Delete(imagePath);
			}
		}
	}
}

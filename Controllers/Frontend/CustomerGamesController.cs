﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cosmos.Models;

namespace Cosmos.Controllers.Frontend
{
	public class CustomerGamesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CustomerGamesController(ApplicationDbContext context)
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
	}
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cosmos.Models;

namespace Cosmos.Controllers.Backend
{
	[Authorize(Roles = "Admin")]
	public class DocumentationController : Controller
	{
		private readonly ILogger<DocumentationController> _logger;

		public DocumentationController(ILogger<DocumentationController> logger)
		{
			_logger = logger;
		}

		public IActionResult Changelog()
		{
			return View();
		}

		public IActionResult Overview()
		{
			return View();
		}

		public IActionResult Database()
		{
			return View();
		}

		public IActionResult SampleGameArt()
		{
			return View();
		}
		public IActionResult HowToAddGame()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

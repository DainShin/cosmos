﻿using System.Net;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cosmos.Models;

namespace Cosmos.Controllers.Frontend;

public class PagesController : Controller
{
	private readonly ILogger<PagesController> _logger;

	public PagesController(ILogger<PagesController> logger)
	{
		_logger = logger;
	}

	public IActionResult Index()
	{
		return View();
	}

	public IActionResult Privacy()
	{
		return View();
	}

	public IActionResult Brief()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}

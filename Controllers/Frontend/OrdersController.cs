using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cosmos.Models;
using Microsoft.AspNetCore.Authorization;
using Cosmos.Services;
using System.Security.Claims;

namespace Cosmos.Controllers
{
	[Authorize(Roles = "Customer")]
	public class OrdersController : Controller
	{
		private readonly CartService _cartService;
		private readonly ApplicationDbContext _context;
		private readonly IConfiguration _configuration;

		public OrdersController(CartService cartService, ApplicationDbContext context, IConfiguration configuration)
		{
			_cartService = cartService;
			_context = context;
			_configuration = configuration;
		}

		public IActionResult Index()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			
			if(userId == null)
			{
				return NotFound();
			}

			var orders = _context.Orders
				.Include(order => order.OrderItems)
				.Include(order => order.User)
				.Where(order => order.UserId == userId)
				.Where(order => order.PaymentReceived == true)
				.OrderByDescending(order => order.Id)
				.ToListAsync();

			return View(orders);
		}

		public async Task<IActionResult> Details(int? id)
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			var order = await _context.Orders
				.Include(order => order.OrderItems)
				.Include(order => order.User)
				.Where(order => order.UserId == userId)
				.FirstOrDefaultAsync(order => order.Id == id);

			return View("Details", order);
		}

		public IActionResult Checkout()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var cart = _cartService.GetCart();

			if (cart == null)
			{
				return NotFound();
			}

			var order = new Order()
			{
				UserId = userId,
				Total = cart.CartItems.Sum(cartItem => cartItem.Quantity * cartItem.Game.Price),
				OrderItems = new List<OrderItem>()
			};

			foreach (var cartItem in cart.CartItems)
			{
				order.OrderItems.Add(new OrderItem()
				{
					OrderId = order.Id,
					ProductName = cartItem.Game.Name,
					Quantity = cartItem.Quantity,
					Price = cartItem.Game.Price
				});

			}

			return View("Details", order);
		}

	}

}

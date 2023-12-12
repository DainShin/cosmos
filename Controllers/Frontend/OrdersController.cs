using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cosmos.Models;
using Microsoft.AspNetCore.Authorization;
using Cosmos.Services;
using System.Security.Claims;
using Stripe;
using Stripe.Checkout;

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

		[Authorize()]
		public async Task<IActionResult> Index()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (userId == null) NotFound();

			var orders = await _context.Orders
				.Include(order => order.OrderItems)
				.Include(order => order.User)
				.Where(order => order.UserId == userId)
				.Where(order => order.PaymentReceived == true)
				.OrderByDescending(order => order.Id)
				.ToListAsync();

			return View(orders);
		}

		[Authorize()]
		public async Task<IActionResult> Details(int? id)
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (userId == null) return NotFound();

			var order = await _context.Orders
				.Include(order => order.OrderItems)
				.Include(order => order.User)
				.Where(order => order.UserId == userId)
				.FirstOrDefaultAsync(order => order.Id == id);

			return View("Details", order);
		}

		[Authorize()]
		public async Task<IActionResult> Checkout()
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
				Total = cart.CartItems.Sum(cartItem => (decimal)(cartItem.Quantity * cartItem.Game.Price)),
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

		[Authorize()]
		[HttpPost]
		public IActionResult ProcessPayment()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			var cart = _cartService.GetCart();

			if (userId == null || cart == null) return NotFound();

			var order = new Order
			{
				UserId = userId,
				Total = cart.CartItems.Sum(CartItem => (decimal)(CartItem.Quantity * CartItem.Game.Price)),
				OrderItems = new List<OrderItem>()
			};

			// Set Stripe API key
			StripeConfiguration.ApiKey = _configuration.GetSection("Stripe")["SecretKey"];

			var options = new SessionCreateOptions
			{
				LineItems = new List<SessionLineItemOptions>
				{
					new SessionLineItemOptions
					{
						PriceData = new SessionLineItemPriceDataOptions
						{
							UnitAmount = (long)order.Total * 100,
							Currency = "cad",
							ProductData = new SessionLineItemPriceDataProductDataOptions
							{
								Name = "Cosmos Purchase"
							}
						},
						Quantity = 1
					}
				},
				PaymentMethodTypes = new List<string>
				{
					"card"
				},
				Mode = "payment",
				SuccessUrl = "https://" + Request.Host + "/Orders/SaveOrder",
				CancelUrl = "https://" + Request.Host + "/Carts/ViewMyCart"
			};

			var service = new SessionService();
			Session session = service.Create(options);
			Response.Headers.Add("Location", session.Url);
			return new StatusCodeResult(303); // 303: permanent redirect
		}

		[Authorize()]
		public async Task<IActionResult> SaveOrder()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			var cart = _cartService.GetCart();

			if (userId == null || cart == null) return NotFound();

			var order = new Order
			{
				UserId = userId,
				Total = cart.CartItems.Sum(cartItem => (decimal)(cartItem.Quantity * cartItem.Game.Price)),
				OrderItems = new List<OrderItem>(),
				PaymentReceived = true
			};

			foreach (var cartItem in cart.CartItems)
			{
				order.OrderItems.Add(new OrderItem
				{
					OrderId = order.Id,
					ProductName = cartItem.Game.Name,
					Quantity = cartItem.Quantity,
					Price = cartItem.Game.Price
				});
			}

			await _context.AddAsync(order);
			await _context.SaveChangesAsync();

			_cartService.DestroyCart();

			return RedirectToAction("Details", new { id = order.Id });
		}
	}
}

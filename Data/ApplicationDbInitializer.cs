using Cosmos.Models;

namespace Cosmos.Data
{
	public class ApplicationDbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

				// Null-check for context
				if (context == null)
				{
					// Log or throw an exception based on your application's requirements
					throw new InvalidOperationException("Unable to retrieve the ApplicationDbContext instance.");
				}
				else
				{
					context.Database.EnsureCreated();

					// Genre
					if (!context.Genres.Any())
					{
						context.Genres.AddRange(new List<Genre>()
					{
						new Genre { Id = 1, Name = "Action", Description = "Action games are characterized by challenges that require fast reflexes, hand-eye coordination, and reaction time. They often include shooting, fighting, and platforming elements." },
						new Genre { Id = 2, Name = "Adventure", Description = "Adventure games often involve story-driven experiences, where players explore environments, interact with characters, and solve puzzles to progress." },
						new Genre { Id = 3, Name = "Role-playing", Description = "Role-playing games (RPGs) allow players to assume the roles of fictional characters, make choices, and often follow an overarching narrative or storyline." },
						new Genre { Id = 4, Name = "Strategy", Description = "Strategy games emphasize skillful thinking and planning to achieve victory, often requiring players to manage resources, armies, or territories." },
						new Genre { Id = 5, Name = "Racing", Description = "Racing games focus on competition where players drive vehicles or other modes of transportation to achieve the fastest times or beat opponents." },
						new Genre { Id = 6, Name = "Shooter", Description = "Shooter games focus on combat involving ranged weapons. Players may view the action from a first-person or third-person perspective." },
						new Genre { Id = 7, Name = "Sports", Description = "Sports games simulate real-world sports like football, basketball, or soccer, allowing players to control a team or individual athletes." },
						new Genre { Id = 8, Name = "Puzzle", Description = "Puzzle games challenge the player's problem-solving skills, requiring them to solve complex puzzles to progress." },
						new Genre { Id = 9, Name = "Platformer", Description = "Platformer games involve guiding a character across a series of platforms, often involving jumping puzzles and avoiding obstacles." },
						new Genre { Id = 10, Name = "Simulation", Description = "Simulation games aim to replicate real-world activities or systems, offering a lifelike experience in various fields like aviation, farming, or city-building." },
					});
						context.SaveChanges();
					}

					// Mode
					if (!context.Modes.Any())
					{
						context.Modes.AddRange(new List<Mode>()
					{
						new Mode { Id = 1, Name = "Single Player", },
						new Mode { Id = 2, Name = "Multiplayer"},
						new Mode { Id = 3, Name = "Co-op"},
						new Mode { Id = 4, Name = "Massively Multiplayer Online"}
					});
						context.SaveChanges();
					}

					// Developer
					if (!context.Developers.Any())
					{
						context.Developers.AddRange(new List<Developer>(){
						new Developer {Id = 1, Name = "Bethesda Game Studios"},
						new Developer {Id = 2, Name = "CD Projekt Red"},
						new Developer {Id = 3, Name = "Rockstar Games"},
						new Developer {Id = 4, Name = "Ubisoft"},
						new Developer {Id = 5, Name = "Electronic Arts"},
						new Developer {Id = 6, Name = "Square Enix"},
						new Developer {Id = 7, Name = "Capcom"},
						new Developer {Id = 8, Name = "Activision"},
						new Developer {Id = 9, Name = "Blizzard Entertainment"},
						new Developer {Id = 10, Name = "Bungie"}
					});
						context.SaveChanges();
					}

					// Publisher
					if (!context.Publishers.Any())
					{
						context.Publishers.AddRange(new List<Publisher>() {
						new Publisher {Id = 1, Name = "Microsoft Studios"},
						new Publisher {Id = 2, Name = "Sony Interactive Entertainment"},
						new Publisher {Id = 3, Name = "Nintendo"},
						new Publisher {Id = 4, Name = "Sega"},
						new Publisher {Id = 5, Name = "Konami"},
						new Publisher {Id = 6, Name = "Bandai Namco Entertainment"},
						new Publisher {Id = 7, Name = "Bethesda Softworks"},
						new Publisher {Id = 8, Name = "Take-Two Interactive"},
						new Publisher {Id = 9, Name = "Warner Bros. Interactive Entertainment"},
						new Publisher {Id = 10, Name = "Deep Silver"}
					});
						context.SaveChanges();
					}

					// Subscription
					if (!context.Subscriptions.Any())
					{
						context.Subscriptions.AddRange(new List<Subscription>() {
						new Subscription {Id = 1, Name = "Free", Price = 0.00M },
						new Subscription {Id = 2, Name = "Advanced", Price = 19.99M },
						new Subscription {Id = 3, Name = "Ultimate", Price = 24.99M }
					});
						context.SaveChanges();
					}
				}
			}
		}
	}
}
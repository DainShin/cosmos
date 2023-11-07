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
						new Developer {Id = 10, Name = "Bungie"},
						new Developer {Id = 11, Name = "Gears for Breakfast"},
						new Developer {Id = 12, Name = "InnerSloth"},
						new Developer {Id = 13, Name = "Studio Wildcard"},
						new Developer {Id = 14, Name = "Bohemia Interactive"},
						new Developer {Id = 15, Name = "Larian Studios"},
						new Developer {Id = 16, Name = "Gearbox Software"},
						new Developer {Id = 17, Name = "Infinity Ward"},
						new Developer {Id = 18, Name = "Remedy Entertainment"},
						new Developer {Id = 19, Name = "Paradox Development Studio"},
						new Developer {Id = 20, Name = "343 Industries"},
						new Developer {Id = 21, Name = "Paradox Development Studio"},
						new Developer {Id = 22, Name = "IO Interactive"},
						new Developer {Id = 23, Name = "Portkey Games"},
						new Developer {Id = 24, Name = "Team Cherry"},
						new Developer {Id = 25, Name = "miHoYo"},
						new Developer {Id = 26, Name = "Crytek"},
						new Developer {Id = 27, Name = "Daniel Mullins Games"},
						new Developer {Id = 28, Name = "Respawn Entertainment"},
						new Developer {Id = 29, Name = "Naughty Dog"},
						new Developer {Id = 30, Name = "Riot Games"},
						new Developer {Id = 31, Name = "Valve Corporation"},
						new Developer {Id = 32, Name = "Round8 Studio"},
						new Developer {Id = 33, Name = "EA Tiburon"},
						new Developer {Id = 34, Name = "BioWare"},
						new Developer {Id = 35, Name = "Kojima Productions"},
						new Developer {Id = 36, Name = "Mojang Studios"},
						new Developer {Id = 37, Name = "Capcom"},
						new Developer {Id = 38, Name = "Visual Concepts"},
						new Developer {Id = 39, Name = "Hello Games"},
						new Developer {Id = 40, Name = "ILCA"},
						new Developer {Id = 41, Name = "Moon Studios"},
						new Developer {Id = 42, Name = "Mobius Digital"},
						new Developer {Id = 43, Name = "Blizzard Entertainment"},
						new Developer {Id = 44, Name = "Ubisoft Montreal"},
						new Developer {Id = 45, Name = "VOID Interactive"},
						new Developer {Id = 46, Name = "Rockstar Games"},
						new Developer {Id = 47, Name = "Insomniac Games"},
						new Developer {Id = 48, Name = "Re-Logic"},
						new Developer {Id = 49, Name = "Monstars Inc."},
						new Developer {Id = 50, Name = "Resonair"},
						new Developer {Id = 51, Name = "Massive Entertainment"},
						new Developer {Id = 52, Name = "Mouldy Toof Studios"},
						new Developer {Id = 53, Name = "Galactic Cafe"},
						new Developer {Id = 54, Name = "Vicarious Visions"},
						new Developer {Id = 55, Name = "Poncle"},
						new Developer {Id = 56, Name = "Gaijin Entertainment"},
						new Developer {Id = 57, Name = "Ryu Ga Gotoku Studio"},
						new Developer {Id = 58, Name = "Konami Digital Entertainment"},
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
						new Publisher {Id = 10, Name = "Deep Silver"},
						new Publisher {Id = 11, Name = "Ubisoft Studios"},
						new Publisher {Id = 12, Name = "Devolver Digital"},
						new Publisher {Id = 13, Name = "Quantic Dream"},
						new Publisher {Id = 14, Name = "505 Games"},
						new Publisher {Id = 15, Name = "Wube Software"},
						new Publisher {Id = 16, Name = "Subset Games"},
						new Publisher {Id = 17, Name = "miHoYo"},
						new Publisher {Id = 18, Name = "10 Chambers Collective"},
						new Publisher {Id = 19, Name = "Supergiant Games"},
						new Publisher {Id = 20, Name = "Xbox Game Studios"},
						new Publisher {Id = 21, Name = "Warner Bros. Interactive Entertainment"},
						new Publisher {Id = 22, Name = "Re-Logic"},
						new Publisher {Id = 23, Name = "505 Games"},
						new Publisher {Id = 24, Name = "Enhance Games"},
						new Publisher {Id = 25, Name = "Electronic Arts"},
						new Publisher {Id = 26, Name = "Team17"},
						new Publisher {Id = 27, Name = "Galactic Cafe"},
						new Publisher {Id = 28, Name = "CD Projekt"},
						new Publisher {Id = 29, Name = "Poncle"},
						new Publisher {Id = 30, Name = "Gaijin Entertainment"},

					});
						context.SaveChanges();
					}

					// Subscription
					if (!context.Subscriptions.Any())
					{
						context.Subscriptions.AddRange(new List<Subscription>() {
						new Subscription {Id = 1, Name = "Basic", Price = 0.00M },
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
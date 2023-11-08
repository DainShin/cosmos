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
						new Developer {Id = 59, Name = "Playground Games"},
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
						new Publisher {Id = 31, Name = "Blizzard Entertainment"},
						new Publisher {Id = 32, Name = "2K Games"},

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

					// Games
					if (!context.Games.Any())
					{
						// Get modes
						var singlePlayer = context.Modes.FirstOrDefault(m => m.Name == "Single Player") ?? new Mode { Name = "Single Player" };
						var multiplayer = context.Modes.FirstOrDefault(m => m.Name == "Multiplayer") ?? new Mode { Name = "Multiplayer" };
						var coop = context.Modes.FirstOrDefault(m => m.Name == "Co-op") ?? new Mode { Name = "Co-op" };
						var mmo = context.Modes.FirstOrDefault(m => m.Name == "Massively Multiplayer Online") ?? new Mode { Name = "Massively Multiplayer Online" };

						if (singlePlayer.Id == 0)
							context.Modes.Add(singlePlayer);
						if (multiplayer.Id == 0)
							context.Modes.Add(multiplayer);
						if (coop.Id == 0)
							context.Modes.Add(coop);
						if (mmo.Id == 0)
							context.Modes.Add(mmo);

						// Save modes to generate IDs
						context.SaveChanges();

						// Get Genres
						var action = context.Genres.FirstOrDefault(g => g.Name == "Action") ?? new Genre { Name = "Action" };
						var adventure = context.Genres.FirstOrDefault(g => g.Name == "Adventure") ?? new Genre { Name = "Adventure" };
						var rolePlaying = context.Genres.FirstOrDefault(g => g.Name == "Role-playing") ?? new Genre { Name = "Role-playing" };
						var strategy = context.Genres.FirstOrDefault(g => g.Name == "Strategy") ?? new Genre { Name = "Strategy" };
						var racing = context.Genres.FirstOrDefault(g => g.Name == "Racing") ?? new Genre { Name = "Racing" };
						var shooter = context.Genres.FirstOrDefault(g => g.Name == "Shooter") ?? new Genre { Name = "Shooter" };
						var sports = context.Genres.FirstOrDefault(g => g.Name == "Sports") ?? new Genre { Name = "Sports" };
						var puzzle = context.Genres.FirstOrDefault(g => g.Name == "Puzzle") ?? new Genre { Name = "Puzzle" };
						var platformer = context.Genres.FirstOrDefault(g => g.Name == "Platformer") ?? new Genre { Name = "Platformer" };
						var simulation = context.Genres.FirstOrDefault(g => g.Name == "Simulation") ?? new Genre { Name = "Simulation" };

						if (action.Id == 0)
							context.Genres.Add(action);
						if (adventure.Id == 0)
							context.Genres.Add(adventure);
						if (rolePlaying.Id == 0)
							context.Genres.Add(rolePlaying);
						if (strategy.Id == 0)
							context.Genres.Add(strategy);
						if (racing.Id == 0)
							context.Genres.Add(racing);
						if (shooter.Id == 0)
							context.Genres.Add(shooter);
						if (sports.Id == 0)
							context.Genres.Add(sports);
						if (puzzle.Id == 0)
							context.Genres.Add(puzzle);
						if (platformer.Id == 0)
							context.Genres.Add(platformer);
						if (simulation.Id == 0)
							context.Genres.Add(simulation);

						// Save genres to generate IDs
						context.SaveChanges();

						// Get Subscriptions
						var basic = context.Subscriptions.FirstOrDefault(s => s.Name == "Basic") ?? new Subscription { Name = "Basic" };
						var advanced = context.Subscriptions.FirstOrDefault(s => s.Name == "Advanced") ?? new Subscription { Name = "Advanced" };
						var ultimate = context.Subscriptions.FirstOrDefault(s => s.Name == "Ultimate") ?? new Subscription { Name = "Ultimate" };

						if (basic.Id == 0)
							context.Subscriptions.Add(basic);
						if (advanced.Id == 0)
							context.Subscriptions.Add(advanced);
						if (ultimate.Id == 0)
							context.Subscriptions.Add(ultimate);

						// Save subscriptions to generate IDs
						context.SaveChanges();

						context.Games.AddRange(new List<Game>() {
							new Game {
								Id = 1,
								Name = "Starfield",
								Description = "Starfield is an action role-playing game developed by Bethesda Game Studios and published by Bethesda Softworks. It was announced during Bethesda's E3 presentation in 2018. The game takes place in a space-themed setting, and is the first new intellectual property developed by Bethesda in 25 years.",
								ImagePath = "images/sample-game-art/starfield.jpeg",
								ReleaseDate = DateTime.Parse("2023-10-29"),
								Price = 89.99M,
								DeveloperId = 1,
								PublisherId = 7,
								IsProtected = true,
								Modes =  new List<Mode>() {singlePlayer},
								Genres = new List<Genre>() {action, adventure, shooter, rolePlaying},
								Subscriptions = new List<Subscription>() {advanced, ultimate}
							},
							new Game {
								Id = 2,
								Name = "Diablo 4",
								Description = "Diablo IV is a 2023 online-only action role-playing game developed and published by Blizzard Entertainment. It is the fourth main installment in the Diablo series.",
								ImagePath = "images/sample-game-art/diablo.jpg",
								ReleaseDate = DateTime.Parse("2023-05-05"),
								Price = 75.00M,
								DeveloperId = 9,
								PublisherId = 31,
								IsProtected = true,
								Modes =  new List<Mode>() {singlePlayer, mmo},
								Genres = new List<Genre>() {action, adventure, rolePlaying},
								Subscriptions = new List<Subscription>() {advanced}	
							},
							new Game {
								Id = 3,
								Name = "Forza Horizon 5",
								Description = "Forza Horizon 5 is a 2021 racing video game developed by Playground Games and published by Xbox Game Studios. It is the fifth Forza Horizon title and twelfth main instalment in the Forza series. The game is set in a fictionalised representation of Mexico.",
								ImagePath = "images/sample-game-art/forza.jpg",
								ReleaseDate = DateTime.Parse("2021-11-01"),
								Price = 79.99M,
								DeveloperId = 58,
								PublisherId = 20,
								IsProtected = true,
								Modes =  new List<Mode>() {singlePlayer, multiplayer},
								Genres = new List<Genre>() {racing},
								Subscriptions = new List<Subscription>() {basic, advanced}
							},
							new Game {
								Id = 4,
								Name = "NBA 2K23",
								Description = "NBA 2K23 is a 2022 basketball video game developed by Visual Concepts and published by 2K, based on the National Basketball Association. It is the 24th installment in the NBA 2K franchise, the successor to NBA 2K22 and the predecessor to NBA 2K24",
								ImagePath = "images/sample-game-art/2k23.jpg",
								ReleaseDate = DateTime.Parse("2022-09-08"),
								Price = 79.99M,
								DeveloperId = 38,
								PublisherId = 32,
								IsProtected = true,
								Modes =  new List<Mode>() {singlePlayer, multiplayer},
								Genres = new List<Genre>() {sports, simulation},
								Subscriptions = new List<Subscription>() {basic}	
							},

						});
						context.SaveChanges();
					}
				}
			}
		}
	}
}
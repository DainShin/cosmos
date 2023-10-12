using Microsoft.EntityFrameworkCore;

namespace Cosmos.Models
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
		public DbSet<Mode> Modes { get; set; }
		public DbSet<Developer> Developers {get; set;}
		public DbSet<Publisher> Publishers {get; set;}
        public DbSet<Subscription> Subscriptions {get; set;}

		// Seed data
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Genre>().HasData(
				new Genre { Id = 1, Name = "Action", Description = "Action games usually involve elements of physical conflict, such as fast paced fighting, combat, racing, platforming, and sometimes exploration." },
				new Genre { Id = 2, Name = "Adventure", Description = "Adventure games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation." },
				new Genre { Id = 3, Name = "Role-playing", Description = "Role-playing games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation."},
				new Genre { Id = 4, Name = "Strategy", Description = "Strategy games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation."},
				new Genre { Id = 5, Name = "Racing", Description = "Racing games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation."},
				new Genre { Id = 6, Name = "Shooter", Description = "Shooter games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation."},
				new Genre { Id = 7, Name = "Sports", Description = "Sports games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation." },
				new Genre { Id = 8, Name = "Puzzle", Description = "Puzzle games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation." },
				new Genre { Id = 9, Name = "Platformer", Description = "Platformer games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation." },
				new Genre { Id = 10, Name = "Simulation", Description = "Simulation games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation." }
			);

			builder.Entity<Mode>().HasData(
				new Mode { Id = 1, Name = "Single Player", },
				new Mode { Id = 2, Name = "Multiplayer"},
				new Mode { Id = 3, Name = "Co-op"},
				new Mode { Id = 4, Name = "Massively Multiplayer Online"}
			);

			builder.Entity<Developer>().HasData(
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
			);

			builder.Entity<Publisher>().HasData(
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
			);

			builder.Entity<Subscription>().HasData(
				new Subscription {Id = 1, Name = "Free", Price = 0.00M },
				new Subscription {Id = 2, Name = "Advanced", Price = 19.99M },
				new Subscription {Id = 3, Name = "Ultimate", Price = 24.99M }
			);
		}
    }
}
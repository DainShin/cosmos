using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cosmos.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
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
    }
}
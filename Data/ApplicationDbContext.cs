using Microsoft.EntityFrameworkCore;

namespace Cosmos.Models
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Subscription> Subscriptions {get; set;}
    }
}
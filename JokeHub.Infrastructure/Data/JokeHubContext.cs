using JokeHub.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace JokeHub.Infrastructure.Data
{
    public class JokeHubContext : DbContext
    {
        public DbSet<Joke> Jokes { get; set; }
        public DbSet<Category> Categories { get; set; }

        public JokeHubContext(DbContextOptions<JokeHubContext> options) : base(options)
        {

        }
    }
}

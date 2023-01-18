using JokeHub.Infrastructure.Data;

namespace JokeHub.Infrastructure.Services
{
    public class UnitOfWork
    {
        private readonly JokeHubContext _context;
        public UnitOfWork(JokeHubContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}

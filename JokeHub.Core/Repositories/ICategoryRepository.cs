using JokeHub.Core.Entities;

namespace JokeHub.Core.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category> CreateAsync(Category entity);
    }
}

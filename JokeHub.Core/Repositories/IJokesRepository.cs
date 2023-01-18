using JokeHub.Core.Entities;

namespace JokeHub.Core.Repositories
{
    public interface IJokesRepository
    {
        Task<Joke> GetByIdAsync(Guid id);
        Task<IEnumerable<Joke>> GetAllAsync();
        Task<Joke> CreateAsync(Joke entity); 
        Task<Joke> UpdateAsync(Joke entity);
        Task<Joke> DeleteAsync(Joke entity);
        Task<IEnumerable<Joke>> GetAllFilteredAsync(List<string> filterCategories);
    }
}

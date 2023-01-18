using JokeHub.Core.Entities;
using JokeHub.Core.Repositories;
using JokeHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JokeHub.Infrastructure.Repositories.Jokes
{
    public class JokesRepository : IJokesRepository
    {
        private readonly JokeHubContext _db;

        public JokesRepository(JokeHubContext db)
        {
            _db = db;
        }

        private DbSet<Joke> GetTable()
        {
            return _db.Set<Joke>();
        }

        private Joke Create(Joke entity)
        {
            return GetTable().Add(entity).Entity;
        }

        public async Task<Joke> CreateAsync(Joke entity)
        {
            return await Task.FromResult(Create(entity));
        }


        private Joke Delete(Joke entity)
        {
            return GetTable().Remove(entity).Entity;
        }

        public async Task<Joke> DeleteAsync(Joke entity)
        {
            return await Task.FromResult(Delete(entity));
        }

        public async Task<IEnumerable<Joke>> GetAllAsync()
        {
            return await GetTable().OrderByDescending(x => x.CreatedAt).Include(x => x.Category).ToListAsync();
        }

        public async Task<IEnumerable<Joke>> GetAllFilteredAsync(List<string> filterCategories)
        {
            filterCategories.Add("Default");
            
            var jokes = await GetAllAsync();
            List<Joke> filteredList = new List<Joke>();

            foreach (var filter in filterCategories)
            {
                var output = jokes.Where(x => x.Category.Name == filter);

                foreach (var item in output)
                {
                    filteredList.Add(item);
                }
            }
            return filteredList;
        }


        private Joke Update(Joke entity)
        {
            return GetTable().Update(entity).Entity;
        }

        public async Task<Joke> UpdateAsync(Joke entity)
        {
            return await Task.FromResult(Update(entity));
        }


        private Joke GetById(Guid id)
        {
            var result = GetTable()
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
            
            return result;
        }
        public async Task<Joke> GetByIdAsync(Guid id)
        {
            var result = await Task.FromResult(GetById(id));
            return result;
        }
    }
}

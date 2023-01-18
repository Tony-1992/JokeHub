using JokeHub.Core.Entities;
using JokeHub.Core.Repositories;
using JokeHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeHub.Infrastructure.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JokeHubContext _db;
        public CategoryRepository(JokeHubContext db)
        {
            _db = db;
        }

        private DbSet<Category> GetTable()
        {
            return _db.Set<Category>();
        }


        private Category Create(Category entity)
        {
            return GetTable().Add(entity).Entity;
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            return await Task.FromResult(Create(entity));
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await GetTable().ToListAsync();
        }
    }
}

using JokeHub.Infrastructure.Services.Categories.Dto;
using JokeHub.Infrastructure.Services.Jokes.Dto;

namespace JokeHub.Infrastructure.Services.Categories
{
    public interface ICategoryAppService
    {
        Task<CategoryDto> CreateAsync(CreateCategoryDto input);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    }
}

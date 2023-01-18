using JokeHub.Infrastructure.Services.Categories.Dto;

namespace JokeHub.Web.Models.Categories
{
    public class IndexCategoryViewModel
    {
        public IEnumerable<CategoryDto> Categories{ get; set; }
    }
}

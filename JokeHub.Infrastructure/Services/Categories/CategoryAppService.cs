using AutoMapper;
using JokeHub.Core.Entities;
using JokeHub.Core.Repositories;
using JokeHub.Infrastructure.Services.Categories.Dto;
using JokeHub.Infrastructure.Services.Jokes.Dto;

namespace JokeHub.Infrastructure.Services.Categories
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public CategoryAppService(ICategoryRepository categoryRepo, IMapper mapper, UnitOfWork unitOfWork)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto input)
        {
            var entity = _mapper.Map<Category>(input);

            var result = await _categoryRepo.CreateAsync(entity);
            await _unitOfWork.SaveChanges();

            var dto = _mapper.Map<CategoryDto>(result);
            return dto;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categoryEntities = await _categoryRepo.GetAllAsync();
            categoryEntities.OrderBy(x => x.CreatedAt);

            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);

            return categoryDtos;
        }
    }
}

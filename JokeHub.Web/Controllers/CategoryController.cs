using JokeHub.Infrastructure.Services.Categories;
using JokeHub.Infrastructure.Services.Categories.Dto;
using JokeHub.Web.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace JokeHub.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }


        public async Task<IActionResult> Index()
        {
            var model = new IndexCategoryViewModel();

            var listOfDtos = await _categoryAppService.GetAllCategoriesAsync();

            model.Categories = listOfDtos;
            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                View(model);

            var dto = new CreateCategoryDto()
            {
                Name = model.Name
            };

            await _categoryAppService.CreateAsync(dto);
            return RedirectToAction("Index", "Home");
        }
    }
}

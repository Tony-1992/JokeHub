using JokeHub.Infrastructure.Services.Categories;
using JokeHub.Infrastructure.Services.Categories.Dto;
using JokeHub.Infrastructure.Services.Jokes;
using JokeHub.Infrastructure.Services.Jokes.Dto;
using JokeHub.Web.Models;
using JokeHub.Web.Models.Jokes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JokeHub.Web.Controllers
{
    public class JokeController : Controller
    {
        private readonly IJokesAppService _jokesAppService;
        private readonly ICategoryAppService _categoryAppService;

        public JokeController(IJokesAppService jokesAppService, ICategoryAppService categoryAppService)
        {
            _jokesAppService = jokesAppService;
            _categoryAppService = categoryAppService;
        }


        public async Task<IActionResult> Index()
        {
            var model = new IndexJokeViewModel();

            var listOfDtos = await _jokesAppService.GetAllJokesAsync();

            model.Jokes = listOfDtos;
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = new CreateJokeViewModel();

            var categoryDtos = await _categoryAppService.GetAllCategoriesAsync();

            model.Categories = categoryDtos.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateJokeViewModel model)
        {
            IEnumerable<CategoryDto> categoriesDto;

            if (ModelState.IsValid)
            {
                var dto = new CreateJokeDto()
                {
                    Setup = model.Setup,
                    PunchLine = model.PunchLine,
                    CategoryId = Guid.Parse(model.CategoryId),
                };

                if (await _jokesAppService.DoesJokeExist(dto))
                {
                    categoriesDto = await _categoryAppService.GetAllCategoriesAsync();
                    model.Categories = categoriesDto.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    });

                    ModelState.AddModelError("Setup", "Joke already exists");
                    return View(model);
                }

                await _jokesAppService.CreateAsync(dto);
                return RedirectToAction("Index", "Home");
            }


            categoriesDto = await _categoryAppService.GetAllCategoriesAsync();
            model.Categories = categoriesDto.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View(model);
        }


        [HttpPost]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dto = new DeleteJokeDto()
            {
                Id = id
            };

            await _jokesAppService.DeleteJoke(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var jokeDto = await _jokesAppService.GetJokeByIdAsync(id);
            var categoryDtos = await _categoryAppService.GetAllCategoriesAsync();

            IEnumerable<SelectListItem> categories = categoryDtos.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var model = new EditJokeViewModel()
            {
                Id = jokeDto.Id,
                Setup = jokeDto.Setup,
                PunchLine = jokeDto.PunchLine,
                CategoryId = jokeDto.Category.Id.ToString(),
                Categories = categories
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditJokeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new UpdateJokeDto()
            {
                Id = model.Id,
                Setup = model.Setup,
                PunchLine = model.PunchLine,
                CategoryId = Guid.Parse(model.CategoryId),
            };

            await _jokesAppService.UpdateAsync(dto);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Random()
        {
            List<string> filters = new List<string>();

            var dto = await _jokesAppService.GetRandomJokeAsync(filters);
            var model = new RandomJokeViewModel()
            {
                Setup = dto.Setup,
                Punchline = dto.PunchLine,
                Category = dto.Category,
            };

            return View(model);
        }

    }
}

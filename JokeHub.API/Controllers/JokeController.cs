using JokeHub.Infrastructure.Services.Jokes;
using Microsoft.AspNetCore.Mvc;

namespace JokeHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        private readonly IJokesAppService _jokesAppService;

        public JokeController(IJokesAppService jokesAppService)
        {
            _jokesAppService = jokesAppService;
        }

        [HttpPost]
        [Route("GetRandomJoke")]
        public async Task<IActionResult> GetRandomJokeAsync(string[] input)
        {
            var filters = input.ToList();

            var jokeDto = await _jokesAppService.GetRandomJokeAsync(filters);
            return Ok(jokeDto);
        }
    }
}

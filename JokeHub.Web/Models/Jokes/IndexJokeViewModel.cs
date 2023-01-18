using JokeHub.Infrastructure.Services.Jokes.Dto;

namespace JokeHub.Web.Models.Jokes
{
    public class IndexJokeViewModel
    {
        public IEnumerable<JokeDto> Jokes { get; set; }
    }
}

using JokeHub.Core.Entities;

namespace JokeHub.Web.Models.Jokes
{
    public class RandomJokeViewModel
    {
        public string Setup { get; set; }
        public string Punchline { get; set; }
        public Category Category { get; set; }
    }
}

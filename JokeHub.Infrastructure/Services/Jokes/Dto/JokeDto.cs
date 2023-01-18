using JokeHub.Core.Entities;

namespace JokeHub.Infrastructure.Services.Jokes.Dto
{
    public class JokeDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Setup { get; set; }
        public string PunchLine { get; set; }
        public Category Category { get; set; }
    }
}

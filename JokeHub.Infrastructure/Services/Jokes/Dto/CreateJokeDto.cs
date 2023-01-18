namespace JokeHub.Infrastructure.Services.Jokes.Dto
{
    public class CreateJokeDto
    {
        public string Setup { get; set; }
        public string PunchLine { get; set; }
        public Guid CategoryId { get; set; }
    }
}

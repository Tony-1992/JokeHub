namespace JokeHub.Infrastructure.Services.Jokes.Dto
{
    public class UpdateJokeDto
    {
        public Guid Id { get; set; }
        public string Setup { get; set; }
        public string PunchLine { get; set; }
        public Guid CategoryId { get; set; }
    }
}

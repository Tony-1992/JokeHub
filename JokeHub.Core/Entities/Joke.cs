namespace JokeHub.Core.Entities
{
    public class Joke
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Setup { get; set; }
        public string PunchLine { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get;set; }
    }
}

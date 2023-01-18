namespace JokeHub.Core.Entities
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Name { get; set; }
    }
}

namespace JokeHub.Infrastructure.Services.Categories.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; set; } 
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public int JokeCount { get; set; }
    }
}

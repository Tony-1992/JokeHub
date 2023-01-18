using JokeHub.Infrastructure.Services.Jokes.Dto;

namespace JokeHub.Infrastructure.Services.Jokes
{
    public interface IJokesAppService
    {
        Task<JokeDto> CreateAsync(CreateJokeDto input);
        Task<JokeDto> UpdateAsync(UpdateJokeDto input);
        Task DeleteJoke(DeleteJokeDto input);
        Task<IEnumerable<JokeDto>> GetAllJokesAsync();
        Task<JokeDto> GetJokeByIdAsync(Guid input);
        Task<JokeDto> GetRandomJokeAsync(List<string> filters);
        Task<bool> DoesJokeExist(CreateJokeDto input);
    }
}

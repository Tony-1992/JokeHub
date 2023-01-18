using AutoMapper;
using JokeHub.Core.Entities;
using JokeHub.Core.Repositories;
using JokeHub.Infrastructure.Services.Jokes.Dto;

namespace JokeHub.Infrastructure.Services.Jokes
{
    public class JokesAppService : IJokesAppService
    {
        private readonly IJokesRepository _jokesRepo;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public JokesAppService(IJokesRepository jokesRepo, IMapper mapper, UnitOfWork unitOfWork)
        {
            _jokesRepo = jokesRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<JokeDto> CreateAsync(CreateJokeDto input)
        {
            var entity = _mapper.Map<Joke>(input);

            var result = await _jokesRepo.CreateAsync(entity);
            await _unitOfWork.SaveChanges();

            var dto = _mapper.Map<JokeDto>(result);
            return dto;
        }

        public async Task DeleteJoke(DeleteJokeDto input)
        {
            var ent = await _jokesRepo.GetByIdAsync(input.Id);
            await _jokesRepo.DeleteAsync(ent);
            await _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<JokeDto>> GetAllJokesAsync()
        {
            var jokeEntities = await _jokesRepo.GetAllAsync();

            var jokeDtos = _mapper.Map<IEnumerable<JokeDto>>(jokeEntities);

            return jokeDtos;
        }

        public async Task<JokeDto> GetJokeByIdAsync(Guid id)
        {
            var entity = await _jokesRepo.GetByIdAsync(id);
            return _mapper.Map<JokeDto>(entity);
        }

        public async Task<JokeDto> GetRandomJokeAsync(List<string> filters)
        {
            var jokesEnt = await _jokesRepo.GetAllFilteredAsync(filters);
            
            var rnd = new Random();
            
            var ind = rnd.Next(0, jokesEnt.Count());
            var joke = jokesEnt.ElementAt(ind);

            return _mapper.Map<JokeDto>(joke);
        }

        public async Task<JokeDto> UpdateAsync(UpdateJokeDto input)
        {
            var updated = _mapper.Map<Joke>(input);

            var res = await _jokesRepo.UpdateAsync(updated);
            await _unitOfWork.SaveChanges();

            return _mapper.Map<JokeDto>(res);
        }

        public async Task<bool> DoesJokeExist(CreateJokeDto joke)
        {
            var jokeEntities = await _jokesRepo.GetAllAsync();
            var exists = jokeEntities.FirstOrDefault(x => x.PunchLine.ToLower() == joke.PunchLine.ToLower());
            
            return exists is null ? false : true;
        }
    }
}

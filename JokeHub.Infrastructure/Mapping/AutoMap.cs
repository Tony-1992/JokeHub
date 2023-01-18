using AutoMapper;
using JokeHub.Core.Entities;
using JokeHub.Infrastructure.Services.Categories.Dto;
using JokeHub.Infrastructure.Services.Jokes.Dto;

namespace JokeHub.Infrastructure.Mapping
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            // Joke Mapping
            CreateMap<Joke, JokeDto>().ReverseMap();
            CreateMap<Joke, CreateJokeDto>().ReverseMap();
            CreateMap<Joke, DeleteJokeDto>().ReverseMap();
            CreateMap<Joke, UpdateJokeDto>().ReverseMap();

            // Category Mapping
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();

        }
    }
}

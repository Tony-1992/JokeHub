using JokeHub.Core.Repositories;
using JokeHub.Infrastructure.Data;
using JokeHub.Infrastructure.Repositories.Categories;
using JokeHub.Infrastructure.Repositories.Jokes;
using JokeHub.Infrastructure.Services;
using JokeHub.Infrastructure.Services.Categories;
using JokeHub.Infrastructure.Services.Jokes;

namespace JokeHub.Web.Extensions
{
    public static class IServiceCollectionExtensions
    {

        public static IServiceCollection RegisterDBcontextService(this IServiceCollection services)
        {
            services.AddScoped<JokeHubContext, JokeHubContext>();
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IJokesRepository, JokesRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }

        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IJokesAppService, JokesAppService>();
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<UnitOfWork>();
            return services;
        }

        public static IServiceCollection RegisterMappingServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}

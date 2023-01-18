using JokeHub.Core.Repositories;
using JokeHub.Infrastructure.Data;
using JokeHub.Infrastructure.Repositories.Jokes;
using JokeHub.Infrastructure.Services.Jokes;
using JokeHub.Infrastructure.Services;

namespace JokeHub.API.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection RegisterDBcontextService(this IServiceCollection services)
        {
            services.AddScoped<JokeHubContext, JokeHubContext>();
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IJokesRepository, JokesRepository>();
            return services;
        }

        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IJokesAppService, JokesAppService>();
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

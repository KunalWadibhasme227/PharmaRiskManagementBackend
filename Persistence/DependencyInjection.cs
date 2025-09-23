using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Services.IRepositories;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastuctureDI(this IServiceCollection services)
        {
            // Register your services here
            // Example: service.AddScoped<IYourService, YourService>();

            services.AddScoped<IRepositoryManager, RepositoryManager>();

           

            return services;
        }
    }
}

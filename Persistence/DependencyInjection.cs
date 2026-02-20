using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repositories.Pharma_RM;
using Services.IRepositories;
using Services.IRepositories.Pharma_RM;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastuctureDI(this IServiceCollection services)
        {
            // Register your services here
            // Example: service.AddScoped<IYourService, YourService>();
            services.AddScoped<IUploadDocumentRepository, UploadDocumentRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

           

            return services;
        }
    }
}

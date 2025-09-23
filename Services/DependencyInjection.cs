using Microsoft.Extensions.DependencyInjection;
using Services.IServices;
using Services.Managers;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesDI(this IServiceCollection services)
        {
            // Register your services here
            // Example: service.AddScoped<IYourService, YourService>();

            services.AddScoped<IServiceManager, ServiceManager>();

            #region Pharma RM Dependecies
            // Add dependecies here
           
            
            #endregion


            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Services.IServices;
using Services.IServices.Pharma_RM;
using Services.Managers;
using Services.Services.Pharma_RM;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesDI(this IServiceCollection services)
        {
            // Register your services here
            // Example: service.AddScoped<IYourService, YourService>();

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IUploadDocumentService, UploadDocumentService>();
            services.AddScoped<IFileUploadService, FileService>();

            #region Pharma RM Dependecies
            // Add dependecies here


            #endregion


            return services;
        }
    }
}

using Persistence;
using Services;

namespace WebApi.Configuration
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection servicesCollection)
        {
            #region Services
            servicesCollection.AddServicesDI()
                .AddInfrastuctureDI();
            #endregion

            return servicesCollection;
        }
    }
}

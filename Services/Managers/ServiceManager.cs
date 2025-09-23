
using Services.IRepositories;
using Services.IServices;
using Services.IServices.Pharma_RM;
using Services.Services.Pharma_RM;

namespace Services.Managers
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuditTypeService> _auditTypeService;
        private readonly Lazy<IAuditorService> _auditorService;

        public ServiceManager(IRepositoryManager repository)
        {
            _auditTypeService = new Lazy<IAuditTypeService>(() =>
                new AuditTypeService(repository));
            _auditorService = new Lazy<IAuditorService>(() =>
                new AuditorService(repository));
        }

        public IAuditTypeService AuditTypeService => _auditTypeService.Value;
        public IAuditorService AuditorService => _auditorService.Value;
    }
}

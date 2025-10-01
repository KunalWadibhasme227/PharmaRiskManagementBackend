
using Services.IRepositories;
using Services.IServices;
using Services.IServices.Pharma_RM;
using Services.IServices.Shared;
using Services.Services.Pharma_RM;

namespace Services.Managers
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuditTypeService> _auditTypeService;
        private readonly Lazy<IAuditorService> _auditorService;
        private readonly Lazy<ICommonService> _commonService;
        private readonly Lazy<IAuditService> _auditService;
        private readonly Lazy<IFindingService> _findingService;
        public ServiceManager(IRepositoryManager repository)
        {
            _auditTypeService = new Lazy<IAuditTypeService>(() =>
                new AuditTypeService(repository));
            _auditorService = new Lazy<IAuditorService>(() =>
                new AuditorService(repository));

            _auditService = new Lazy<IAuditService>(() => new AuditService(repository));
            _commonService = new Lazy<ICommonService>(() => new CommonService(repository));
            _findingService = new Lazy<IFindingService>(() => new FindingService(repository));
        }

        public IAuditTypeService AuditTypeService => _auditTypeService.Value;
        public IAuditorService AuditorService => _auditorService.Value;
        public ICommonService CommonService => _commonService.Value;
        public IAuditService AuditService => _auditService.Value;
        public IFindingService FindingService => _findingService.Value;
    }
}

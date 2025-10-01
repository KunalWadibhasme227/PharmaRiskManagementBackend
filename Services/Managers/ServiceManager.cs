﻿
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
        private readonly Lazy<ICategoryService> _categoryService;
        public ServiceManager(IRepositoryManager repository)
        {
            _auditTypeService = new Lazy<IAuditTypeService>(() =>
                new AuditTypeService(repository));
            _categoryService = new Lazy<ICategoryService>(() =>
                new CategoryService(repository));
            _auditorService = new Lazy<IAuditorService>(() =>
                new AuditorService(repository));

            _auditService = new Lazy<IAuditService>(() => new AuditService(repository));
            _commonService = new Lazy<ICommonService>(() => new CommonService(repository)); 
        }

        public IAuditTypeService AuditTypeService => _auditTypeService.Value;
        public IAuditorService AuditorService => _auditorService.Value;
        public ICommonService CommonService => _commonService.Value;
        public IAuditService AuditService => _auditService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
    }
}

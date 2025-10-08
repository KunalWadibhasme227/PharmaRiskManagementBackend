using Microsoft.AspNetCore.Hosting;
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
        private readonly Lazy<IDocumentService> _fileService;
        private readonly Lazy<IDocumentService> _documentService;
        private readonly Lazy<IFileUploadService> _fileUploadService;
        private readonly Lazy<IUploadDocumentService> _uploadDocumentService;

        private readonly Lazy<ICategoryService> _categoryService;
        public ServiceManager(IRepositoryManager repository, IWebHostEnvironment hostingEnvironment)
        {
            _auditTypeService = new Lazy<IAuditTypeService>(() =>
                new AuditTypeService(repository));
            _categoryService = new Lazy<ICategoryService>(() =>
                new CategoryService(repository));
            _auditorService = new Lazy<IAuditorService>(() =>
                new AuditorService(repository));

            _auditService = new Lazy<IAuditService>(() => new AuditService(repository));
            _commonService = new Lazy<ICommonService>(() => new CommonService(repository));
            _findingService = new Lazy<IFindingService>(() => new FindingService(repository));
            _fileUploadService = new Lazy<IFileUploadService>(() => new FileService(hostingEnvironment));
            _uploadDocumentService = new Lazy<IUploadDocumentService>(() =>
               new UploadDocumentService(repository,_fileUploadService.Value));
        }

        public IAuditTypeService AuditTypeService => _auditTypeService.Value;
        public IAuditorService AuditorService => _auditorService.Value;
        public ICommonService CommonService => _commonService.Value;
        public IAuditService AuditService => _auditService.Value;
        public IFindingService FindingService => _findingService.Value;
        public IDocumentService FileService => _fileService.Value;
        public IDocumentService DocumentService => _documentService.Value;
        public IFileUploadService FileUploadService => _fileUploadService.Value;
        public ICategoryService CategoryService => _categoryService.Value;

        public IUploadDocumentService UploadDocumentService => _uploadDocumentService.Value;
    }
}

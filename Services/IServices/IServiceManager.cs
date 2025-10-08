

using Services.IServices.Pharma_RM;
using Services.IServices.Shared;
using Services.Services.Pharma_RM;

namespace Services.IServices
{
    public interface IServiceManager
    {
        IAuditTypeService AuditTypeService { get; }
        IAuditorService AuditorService { get; }
        ICommonService CommonService { get; }
        IAuditService AuditService { get; }
        IFindingService FindingService { get; }
        ICategoryService CategoryService { get; }
        IDocumentService FileService { get; }
        IDocumentService DocumentService { get; }
    }
}

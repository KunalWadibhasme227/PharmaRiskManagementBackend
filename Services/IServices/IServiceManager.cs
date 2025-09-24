

using Services.IServices.Pharma_RM;
using Services.IServices.Shared;

namespace Services.IServices
{
    public interface IServiceManager
    {
        IAuditTypeService AuditTypeService { get; }
        IAuditorService AuditorService { get; }
        ICommonService CommonService { get; }
        IAuditService AuditService { get; }
    }
}

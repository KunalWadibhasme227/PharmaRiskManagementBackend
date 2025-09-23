

using Services.IServices.Pharma_RM;

namespace Services.IServices
{
    public interface IServiceManager
    {
        IAuditTypeService AuditTypeService { get; }
        IAuditorService AuditorService { get; }
    }
}

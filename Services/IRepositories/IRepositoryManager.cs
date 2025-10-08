
using Services.IRepositories.Pharma_RM;
using System.Reflection.Metadata;

namespace Services.IRepositories
{
    public interface IRepositoryManager
    {
        
        IAuditTypeRepository AuditType { get; }
        IAuditorRepository Auditor { get; }
        IMasterGlobalCodeRepository MasterGlobalCode { get; }
        IMasterGlobalCodeTypeRepository MasterGlobalCodeType { get; }
        ICommonApiRepository CommonApiRepository { get; }
        IAuditRepository Audit { get; }
        IFindingRepository Finding { get; }
        IDocumentRepository Document { get; }

        IGlobalDocumentRepository GlobalDocument { get; }
        ICategoryRepository Category { get; }
        IUploadDocumentRepository UploadDocument { get; }

        Task SaveAsync();
    }
}

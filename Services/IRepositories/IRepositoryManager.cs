
using Services.IRepositories.Pharma_RM;
using System.Reflection.Metadata;

namespace Services.IRepositories
{
    public interface IRepositoryManager
    {
        // Question Bank
        //IMasterCategoryRepository MasterCategoryRepository { get; }


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

        IMaterialRepository Material { get; }
        IHandlingProcedureRepository HandlingProcedure { get; }
        Task SaveAsync();
    }
}

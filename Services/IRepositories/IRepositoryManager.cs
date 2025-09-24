
using Services.IRepositories.Pharma_RM;

namespace Services.IRepositories
{
    public interface IRepositoryManager
    {
        // Question Bank
        //IMasterCategoryRepository MasterCategoryRepository { get; }


        IAuditTypeRepository AuditType { get; }
        IAuditorRepository Auditor { get; }
        IAuditRepository Audit { get; }

        Task SaveAsync();
    }
}

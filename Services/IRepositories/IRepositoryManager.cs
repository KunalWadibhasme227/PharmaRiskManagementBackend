
using Services.IRepositories.Pharma_RM;

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
        Task SaveAsync();
    }
}

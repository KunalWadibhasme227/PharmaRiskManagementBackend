using Common.Models.Dtos.Pharma_RM.FindingFolder;
using Domain.Entities.Pharma_RM;

namespace Services.IRepositories.Pharma_RM
{
    public interface IFindingRepository
    {
        Task<IEnumerable<Finding>> GetAllAsync(string? filter);
        Task<Finding?> GetByIdAsync(Guid id);
        Task<Finding> CreateAsync(Finding entity);
        Task UpdateAsync(Finding entity);
        Task DeleteAsync(Finding entity);
        Task<FindingsSummaryDto> GetSummaryCountsAsync();
    }
}

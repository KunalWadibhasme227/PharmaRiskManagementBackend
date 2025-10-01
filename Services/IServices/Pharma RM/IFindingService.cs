using Common.Models.Dtos.Pharma_RM.FindingFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Pharma_RM
{
    public interface IFindingService
    {
        Task<IEnumerable<FindingDto>> GetAllAsync(string? filter);
        Task<FindingDto?> GetByIdAsync(Guid id);
        Task<FindingDto> CreateAsync(FindingForCreateDto dto);
        Task UpdateAsync(FindingForUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}

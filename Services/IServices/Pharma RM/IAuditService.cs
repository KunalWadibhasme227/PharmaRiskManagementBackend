using Common.Models.Dtos.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Pharma_RM
{
    public interface IAuditService
    {
        Task<IEnumerable<AuditDto>> GetAllAsync();
        Task<AuditDto?> GetByIdAsync(Guid id);
        Task<AuditDto> CreateAsync(AuditCreateDto dto);
        Task<bool> UpdateAsync(AuditUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}

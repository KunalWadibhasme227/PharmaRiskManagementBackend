using Common.Models.Dtos.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Pharma_RM
{
    public interface IAuditTypeService
    {
        Task<IEnumerable<AuditTypeDto>> GetAllAsync();
        Task<AuditTypeDto?> GetByIdAsync(int id);
        Task<AuditTypeDto> CreateAsync(AuditTypeForCreationDto dto);
        Task<bool> UpdateAsync(int id, AuditTypeForUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }

}

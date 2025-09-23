using Common.Models.Dtos.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Pharma_RM
{
    public interface IAuditorService
    {
        Task<IEnumerable<AuditorDto>> GetAllAsync();
        Task<AuditorDto?> GetByIdAsync(int id);
        Task<AuditorDto> CreateAsync(AuditorForCreationDto dto);
        Task<bool> UpdateAsync(int id, AuditorForUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

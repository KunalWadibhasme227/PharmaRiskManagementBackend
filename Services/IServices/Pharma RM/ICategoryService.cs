using Common.Models.Dtos.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Pharma_RM
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CategoryForCreationDto dto);
        Task<bool> UpdateAsync(int id, CategoryForUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

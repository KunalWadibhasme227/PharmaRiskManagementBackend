using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositories.Pharma_RM
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryMaster>> GetAllAsync();
        //Task<PagedCategoryDetailDto> GetAllAsync(CategoryRequestDto categoryRequestDto);
        Task<CategoryMaster?> GetByIdAsync(int id);
        Task CreateAsync(CategoryMaster category);
        void Update(CategoryMaster category);
        void Delete(CategoryMaster category);
    }
}

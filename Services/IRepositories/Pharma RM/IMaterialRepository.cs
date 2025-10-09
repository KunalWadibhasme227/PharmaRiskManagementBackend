using Common.Models.Dtos.Pharma_RM.MaterialFolder;
using Domain.Entities.Pharma_RM.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositories.Pharma_RM
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Materials>> GetAllAsync();
        Task<PagedMaterialDetailDto> GetAllAsync(MaterialRequestDto materialRequestDto);
        Task<Materials?> GetByIdAsync(Guid id);
        Task<MaterialStorageCondition?> GetByIdformmaterialstorageAsync(Guid id);
        Task AddAsync(Materials material);
        Task AddAsync(MaterialStorageCondition materialStorage);
        void Update(Materials material);
        void UpdateMaterialStorage(MaterialStorageCondition materialStorageCondition);
       // void Delete(Materials material);
        Task SaveAsync();
    }
}

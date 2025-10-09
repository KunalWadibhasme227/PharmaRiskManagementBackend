using Common.Models;
using Common.Models.Dtos.Pharma_RM.MaterialFolder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Pharma_RM
{
    public interface IMaterialService
    {
        Task<ApiResponse<object>> GetAllAsync(MaterialRequestDto materialRequestDto);
        Task<ApiResponse<object>> GetByIdAsync(Guid id);
        Task<ApiResponse<string>> AddAsync(AddMaterialDto dto);
        Task<ApiResponse<string>> UpdateAsync(Guid id, AddMaterialDto dto);
        Task<ApiResponse<string>> DeleteAsync(Guid id);

    }
}

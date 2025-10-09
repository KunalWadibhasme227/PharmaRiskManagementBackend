using Common.Models;
using Common.Models.Dtos.Pharma_RM.MaterialFolder;
using Domain.Entities.Pharma_RM.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Pharma_RM
{
    public interface IHandlingProcedure
    {
        Task<ApiResponse<object>> GetAllAsync();
        Task<ApiResponse<object>> GetByIdAsync(Guid id);
        Task<ApiResponse<string>> AddAsync(HandlingProcedureDto handlingProcedure);
        Task<ApiResponse<string>> UpdateAsync(Guid id, HandlingProcedure handlingProcedure);
        Task<ApiResponse<string>> DeleteAsync(Guid id);
    }
}

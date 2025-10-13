using Common.Models;
using Common.Models.Dtos.Pharma_RM.MaterialFolder;
using Domain.Entities.Pharma_RM.Material;
using Services.IRepositories;
using Services.IRepositories.Pharma_RM;
using Services.IServices.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Pharma_RM
{
    public class HandlingProcedureService : IHandlingProcedure
    {
        private readonly IRepositoryManager _HandlingPro;

        public HandlingProcedureService(IRepositoryManager handlingPro)
        {
            _HandlingPro = handlingPro;
        }

        public async Task<ApiResponse<string>> AddAsync(HandlingProcedureDto handlingProcedure)
        {
            try
            {
                if (handlingProcedure == null)
                    return ApiResponse<string>.Fail("Invalid request data.");
                var handlingprocedure = new HandlingProcedure
                {
                    ProcedureName = handlingProcedure.ProcedureName,
                    LastReviewedDate = handlingProcedure.LastReviewedDate,
                    ComplianceScore = handlingProcedure.ComplianceScore,
                    StatusCodeId = handlingProcedure.StatusCodeId,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1
                };

                var result = _HandlingPro.HandlingProcedure.AddAsync(handlingprocedure);
                await _HandlingPro.SaveAsync();

                return ApiResponse<string>.Ok("Handling Procedure added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Fail("Error adding Procedure.", new() { ex.Message });
            }
        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid id)
        {
            var existing = await _HandlingPro.HandlingProcedure.GetByIdAsync(id);
            if (existing == null)
                return ApiResponse<string>.Fail("Procedure not found.", statusCode: 404);
            existing.IsDeleted = true;
            existing.DeletedBy = 1;
            existing.DeletedDate = DateTime.Now;

            _HandlingPro.HandlingProcedure.Update(existing);
            await _HandlingPro.SaveAsync();
            return ApiResponse<string>.Ok("Procedure Deleted successfully.");
        }

        public async Task<ApiResponse<object>> GetAllAsync()
        {

            var procedure = await _HandlingPro.HandlingProcedure.GetAllAsync();
            return ApiResponse<object>.Ok(procedure, "Procedure fetched successfully.");
        
        }

        public async Task<ApiResponse<object>> GetByIdAsync(Guid id)
        {
            var procedure = await _HandlingPro.HandlingProcedure.GetByIdAsync(id);
            return ApiResponse<object>.Ok(procedure, "Procedure fetched successfully.");
        }

        public async Task<ApiResponse<string>> UpdateAsync(Guid id, HandlingProcedure handlingProcedure)
        {
            var existing = await _HandlingPro.HandlingProcedure.GetByIdAsync(id);
            if (existing == null)
                return ApiResponse<string>.Fail("Procedure not found.", statusCode: 404);

            existing.ProcedureName = handlingProcedure.ProcedureName;
            existing.LastReviewedDate = handlingProcedure.LastReviewedDate;
            existing.StatusCodeId = handlingProcedure.StatusCodeId;
            existing.ComplianceScore = handlingProcedure.ComplianceScore;
            existing.UpdatedBy = 1;
            existing.UpdatedDate = DateTime.UtcNow;

            _HandlingPro.HandlingProcedure.Update(existing);
            await _HandlingPro.SaveAsync();
            return ApiResponse<string>.Ok("Procedure updated successfully.");

        }
    }
}

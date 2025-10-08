using Common.Models;
using Common.Models.Dtos.Pharma_RM.MaterialFolder;
using Domain.Entities.Pharma_RM.Material;
using Microsoft.AspNetCore.Mvc;
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
    public class MaterialService : IMaterialService
    {
        private readonly IRepositoryManager _materialRepository;

        public MaterialService(IRepositoryManager materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<ApiResponse<object>> GetAllAsync()
        {
            var materials = await _materialRepository.Material.GetAllAsync();
            return ApiResponse<object>.Ok(materials, "Materials fetched successfully.");
        }
        public async Task<ApiResponse<object>> GetAllAsync(MaterialRequestDto materialRequestDto)
        {
            var materials = await _materialRepository.Material.GetAllAsync(materialRequestDto);
            return ApiResponse<object>.Ok(materials, "Materials fetched successfully.");
        }

        public async Task<ApiResponse<object>> GetByIdAsync(Guid id)
        {
            var material = await _materialRepository.Material.GetByIdAsync(id);
            if (material == null)
                return ApiResponse<object>.Fail("Material not found.", statusCode: 404);

            return ApiResponse<object>.Ok(material, "Material fetched successfully.");
        }

        public async Task<ApiResponse<string>> AddAsync(AddMaterialDto dto)
        {
            try
            {
                if (dto == null)
                    return ApiResponse<string>.Fail("Invalid request data.");

                string batchNumber = string.IsNullOrWhiteSpace(dto.BatchNumber)
                    ? await GenerateBatchNumberAsync(dto.CategoryCodeId)
                    : dto.BatchNumber;

                var material = new Materials
                {
                    MaterialName = dto.MaterialName,
                    CategoryCodeId = dto.CategoryCodeId,
                    SupplierId = dto.SupplierId,
                    BatchNumber = batchNumber,
                    StatusCodeId = dto.StatusCodeId,
                    ExpiryDate = dto.ExpiryDate,
                    ManufacturingDate = dto.ManufacturingDate
                };

                var result  =  _materialRepository.Material.AddAsync(material);
                await _materialRepository.SaveAsync();
                var materialstorage = new MaterialStorageCondition
                {
                    RequiredHumidity = dto.RequiredHumidity,
                    RequiredTemp = dto.RequiredTemp,
                    MaterialId = material.MaterialId
                };
                await _materialRepository.Material.AddAsync(materialstorage);
                await _materialRepository.SaveAsync();

                return ApiResponse<string>.Ok("Material added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Fail("Error adding material.", new() { ex.Message });
            }
        }

        public async Task<ApiResponse<string>> UpdateAsync(Guid id, AddMaterialDto dto)
        {
            var existing = await _materialRepository.Material.GetByIdAsync(id);
            if (existing == null)
                return ApiResponse<string>.Fail("Material not found.", statusCode: 404);

            existing.MaterialName = dto.MaterialName;
            existing.CategoryCodeId = dto.CategoryCodeId;
            existing.SupplierId = dto.SupplierId;
            existing.StatusCodeId = dto.StatusCodeId;
            existing.ExpiryDate = dto.ExpiryDate;
            existing.ManufacturingDate = dto.ManufacturingDate;
            existing.BatchNumber = dto.BatchNumber ?? existing.BatchNumber;
            existing.UpdatedBy = 1;
            existing.UpdatedDate = DateTime.UtcNow;

            _materialRepository.Material.Update(existing);
            await _materialRepository.SaveAsync();
            
            var matstorage = await _materialRepository.Material.GetByIdformmaterialstorageAsync(id);

            matstorage.RequiredHumidity = dto.RequiredHumidity;
            matstorage.RequiredTemp = dto.RequiredTemp;
            matstorage.UpdatedBy = 1;
            matstorage.UpdatedDate = DateTime.UtcNow;

            _materialRepository.Material.UpdateMaterialStorage(matstorage);
            await _materialRepository.SaveAsync();
            return ApiResponse<string>.Ok("Material updated successfully.");
        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid id)
        {
            var existing = await _materialRepository.Material.GetByIdAsync(id);
            if (existing == null)
                return ApiResponse<string>.Fail("Material not found.", statusCode: 404);
            existing.IsDeleted = true;
            existing.DeletedBy = 1;
            existing.DeletedDate = DateTime.UtcNow;
            _materialRepository.Material.Update(existing);
            await _materialRepository.SaveAsync();

            var matstorage = await _materialRepository.Material.GetByIdformmaterialstorageAsync(id);
            matstorage.IsDeleted = true;
            matstorage.DeletedDate = DateTime.UtcNow;
            matstorage.DeletedBy = 1;
            _materialRepository.Material.UpdateMaterialStorage(matstorage);
            await _materialRepository.SaveAsync();

            return ApiResponse<string>.Ok("Material deleted successfully.");
        }

        private async Task<string> GenerateBatchNumberAsync(int categoryCodeId)
        {
            string categoryPrefix = "MAT";
            var all = await _materialRepository.Material.GetAllAsync();
            int year = DateTime.Now.Year;
            int count = all.Count(m => m.BatchNumber.StartsWith($"{categoryPrefix}-{year}"));
            return $"{categoryPrefix}-{year}-{count + 1:D3}";
        }
    }
}

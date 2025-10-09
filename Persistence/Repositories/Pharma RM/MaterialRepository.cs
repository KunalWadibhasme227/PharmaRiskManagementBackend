using Common.Models.Dtos.Pharma_RM;
using Common.Models.Dtos.Pharma_RM.MaterialFolder;
using Dapper;
using Domain.Entities.Pharma_RM.Material;
using Microsoft.EntityFrameworkCore;
using Services.IRepositories;
using Services.IRepositories.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Pharma_RM
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDbContext _context;


        public MaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Materials>> GetAllAsync()
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task<PagedMaterialDetailDto> GetAllAsync(MaterialRequestDto materialRequestDto)
        {
            using var connection = _context.Database.GetDbConnection();

            var auditRecords = await connection.QueryAsync<GetMaterialDto>(
                "dbo.GetMaterialDetails",
                new
                {
                    //StatusId = materialRequestDto.StatusId,
                    SearchText = materialRequestDto.SearchText,
                    PageNumber = materialRequestDto.PageNumber,
                    PageSize = materialRequestDto.PageSize
                },
                commandType: CommandType.StoredProcedure
            );

            var recordsList = auditRecords.ToList();
            var totalCount = recordsList.FirstOrDefault()?.TotalCount ?? 0;

            return new PagedMaterialDetailDto
            {
                Records = recordsList.ToArray(),
                PageNumber = materialRequestDto.PageNumber,
                PageSize = materialRequestDto.PageSize,
                TotalCount = totalCount
            };
        }


        public async Task<Materials?> GetByIdAsync(Guid id)
        {
            return await _context.Materials.FindAsync(id);
        }

        public async Task<MaterialStorageCondition> GetByIdformmaterialstorageAsync(Guid id)
        {
            return _context.MaterialStorageConditions.Where(x => x.MaterialId == id).FirstOrDefault();
        }

        public async Task AddAsync(Materials material)
        {
            await _context.Materials.AddAsync(material);
        }

        public async Task AddAsync(MaterialStorageCondition materialStorage)
        {
            await _context.MaterialStorageConditions.AddAsync(materialStorage); 
        }

        public void Update(Materials material)
        {
            _context.Materials.Update(material);
        }

        public void UpdateMaterialStorage(MaterialStorageCondition materialstorage)
        {
            _context.MaterialStorageConditions.Update(materialstorage);
        }

        //public void Delete(Materials material)
        //{
        //    _context.Materials.Remove(material);
        //}

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

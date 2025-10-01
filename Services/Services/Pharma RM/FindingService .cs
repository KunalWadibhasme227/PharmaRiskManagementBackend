using Common.Models.Dtos.Pharma_RM.FindingFolder;
using Domain.Entities.Pharma_RM;
using Services.IRepositories;
using Services.IServices.Pharma_RM;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Pharma_RM
{
    public class FindingService : IFindingService
    {
        private readonly IRepositoryManager _repository;

        public FindingService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FindingDto>> GetAllAsync(string? filter)
        {
            var findings = await _repository.Finding.GetAllAsync(filter);
            return findings.Adapt<IEnumerable<FindingDto>>();
        }

        public async Task<FindingDto?> GetByIdAsync(Guid id)
        {
            var finding = await _repository.Finding.GetByIdAsync(id);
            return finding?.Adapt<FindingDto>();
        }

        public async Task<FindingDto> CreateAsync(FindingForCreateDto dto)
        {
            var entity = dto.Adapt<Finding>();
            var created = await _repository.Finding.CreateAsync(entity);
            return created.Adapt<FindingDto>();
        }

        public async Task UpdateAsync(FindingForUpdateDto dto)
        {
            var entity = dto.Adapt<Finding>();
            await _repository.Finding.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.Finding.GetByIdAsync(id);
            if (entity != null)
                await _repository.Finding.DeleteAsync(entity);
        }
        public async Task<FindingsSummaryDto> GetSummaryCountsAsync()
        {
            return await _repository.Finding.GetSummaryCountsAsync();
        }

    }
}

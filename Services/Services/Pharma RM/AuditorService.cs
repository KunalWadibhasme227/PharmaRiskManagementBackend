using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using Services.IRepositories;
using Services.IServices.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Pharma_RM
{
    public class AuditorService : IAuditorService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AuditorService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<AuditorDto>> GetAllAsync()
        {
            var auditors = await _repositoryManager.Auditor.GetAllAsync();
            return auditors.Select(MapToDto);
        }

        public async Task<AuditorDto?> GetByIdAsync(int id)
        {
            var auditor = await _repositoryManager.Auditor.GetByIdAsync(id);
            return auditor is null ? null : MapToDto(auditor);
        }

        public async Task<AuditorDto> CreateAsync(AuditorForCreationDto dto)
        {
            var auditor = new Auditor
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };

            await _repositoryManager.Auditor.CreateAsync(auditor);
            await _repositoryManager.SaveAsync();

            return MapToDto(auditor);
        }

        public async Task<bool> UpdateAsync(int id, AuditorForUpdateDto dto)
        {
            var auditor = await _repositoryManager.Auditor.GetByIdAsync(id);
            if (auditor is null)
                return false;

            auditor.Name = dto.Name;
            auditor.Email = dto.Email;
            auditor.Phone = dto.Phone;

            _repositoryManager.Auditor.Update(auditor);
            await _repositoryManager.SaveAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var auditor = await _repositoryManager.Auditor.GetByIdAsync(id);
            if (auditor is null)
                return false;

            _repositoryManager.Auditor.Delete(auditor);
            await _repositoryManager.SaveAsync();

            return true;
        }

        private static AuditorDto MapToDto(Auditor auditor)
        {
            return new AuditorDto
            {
                AuditorId = auditor.AuditorId,
                Name = auditor.Name,
                Email = auditor.Email,
                Phone = auditor.Phone
            };
        }
    }
}

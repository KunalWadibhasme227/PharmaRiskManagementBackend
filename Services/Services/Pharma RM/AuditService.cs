using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using Mapster;
using Services.IRepositories;
using Services.IServices.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Pharma_RM
{
    public class AuditService : IAuditService
    {
        private readonly IRepositoryManager _repository;

        public AuditService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<PagedAuditDetailDto> GetAllAsync(AuditRequestDto auditRequestDto)
        {
            var audits = await _repository.Audit.GetAllAsync(auditRequestDto);
            return audits.Adapt<PagedAuditDetailDto>();
        }

        public async Task<AuditDto?> GetByIdAsync(Guid id)
        {
            var audit = await _repository.Audit.GetByIdAsync(id);
            return audit?.Adapt<AuditDto>();
        }

        public async Task<AuditDto> CreateAsync(AuditCreateDto dto)
        {
            var entity = dto.Adapt<Audit>(); // Map CreateDto → Entity
            entity.AuditId = Guid.NewGuid();

            await _repository.Audit.CreateAsync(entity);
            await _repository.SaveAsync();

            return entity.Adapt<AuditDto>(); // Map back to DTO
        }

        public async Task<bool> UpdateAsync(AuditUpdateDto dto)
        {
            var audit = await _repository.Audit.GetByIdAsync(dto.AuditId);
            if (audit == null) return false;

            dto.Adapt(audit); // Map UpdateDto → Existing Entity
            _repository.Audit.Update(audit);
            await _repository.SaveAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var audit = await _repository.Audit.GetByIdAsync(id);
            if (audit == null) return false;

            _repository.Audit.Delete(audit);
            await _repository.SaveAsync();

            return true;
        }
    }
}

using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using Mapster;
using Microsoft.Extensions.Logging;
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
       // private readonly ILogger<AuditService> _logger;

        public AuditService(IRepositoryManager repository)
        {
            _repository = repository;
            //_logger = logger;
        }

        public async Task<PagedAuditDetailDto> GetAllAsync(AuditRequestDto auditRequestDto)
        {
            try
            {
                var audits = await _repository.Audit.GetAllAsync(auditRequestDto);
                return audits.Adapt<PagedAuditDetailDto>();
            }
            catch(Exception e)
            {
               // _logger.LogError(e, "Error while fetching Audit Data.");
                throw;
            }
        }

        public async Task<AuditDto?> GetByIdAsync(Guid id)
        {
            try {
                var audit = await _repository.Audit.GetByIdAsync(id);
                return audit?.Adapt<AuditDto>();
            }
            catch(Exception e)
            {
               // _logger.LogError(e, "Error while fetching Audit Data.");
                throw;
            }
            
        }

        public async Task<AuditDto> CreateAsync(AuditCreateDto dto)
        {
            try {
                var entity = dto.Adapt<Audit>(); // Map CreateDto → Entity
                entity.AuditId = Guid.NewGuid();

                await _repository.Audit.CreateAsync(entity);
                await _repository.SaveAsync();

                return entity.Adapt<AuditDto>(); // Map back to DTO
            }
            catch(Exception e)
            {
                //_logger.LogError(e, "Error while creating Audit. Name: {Name}, Email: {Email}", dto.SupplierId, dto.LeadAuditor);
                throw;
            }
            
        }

        public async Task<bool> UpdateAsync(AuditUpdateDto dto)
        {
            try{
                var audit = await _repository.Audit.GetByIdAsync(dto.AuditId);
                if (audit == null)
                {
                   // _logger.LogWarning("Audit with Id {Id} not found for update",dto.AuditId);
                    return false;
                }

                dto.Adapt(audit); // Map UpdateDto → Existing Entity
                _repository.Audit.Update(audit);
                await _repository.SaveAsync();

                return true;
            }
            catch(Exception e)
            {
                //_logger.LogError(e, "Error while updating Audit with Id {Id}.", dto.AuditId);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try {
                var audit = await _repository.Audit.GetByIdAsync(id);
                if (audit == null)
                {
                   // _logger.LogWarning("Attempted to delete Audit with Id {Id}, but it was not found.", id);
                    return false;
                }

                _repository.Audit.Delete(audit);
                await _repository.SaveAsync();

                return true;
            }
            catch(Exception e)
            {
                //_logger.LogError(e, "Error while deleting Auditor with Id {Id}.", id);
                throw;
            }
            
        }
    }
}

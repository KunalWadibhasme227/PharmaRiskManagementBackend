using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
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
    public class AuditorService : IAuditorService
    {
        private readonly IRepositoryManager _repositoryManager;
       // private readonly ILogger<AuditService> _logger;

        public AuditorService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            //_logger = logger;
        }

        public async Task<IEnumerable<AuditorDto>> GetAllAsync()
        {
            try
            {
                var auditors = await _repositoryManager.Auditor.GetAllAsync();
                return auditors.Select(MapToDto);
            }
            catch(Exception e)
            {
                //_logger.LogError(e, "Error while fetching Auditor Data.");
                throw;
            }
        }

        public async Task<AuditorDto?> GetByIdAsync(int id)
        {
            try
            {
                var auditor = await _repositoryManager.Auditor.GetByIdAsync(id);
                return auditor is null ? null : MapToDto(auditor);
            }
            catch(Exception e)
            {
                //_logger.LogError(e, "Error while fetching Auditor Data By Id.");
                throw;
            }
            
        }

        public async Task<AuditorDto> CreateAsync(AuditorForCreationDto dto)
        {
            try {
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
            catch(Exception e)
            {
                //_logger.LogError(e, "Error while creating Auditor. Name: {Name}, Email: {Email}",dto.Name, dto.Email);
                throw;
            }
            
        }

        public async Task<bool> UpdateAsync(int id, AuditorForUpdateDto dto)
        {
            try
            {
                var auditor = await _repositoryManager.Auditor.GetByIdAsync(id);

                if (auditor is null)
                {
                   // _logger.LogWarning("Auditor with Id {Id} not found for update. Name: {Name}, Email: {Email}", id, dto.Name, dto.Email);
                    return false;
                }

                auditor.Name = dto.Name;
                auditor.Email = dto.Email;
                auditor.Phone = dto.Phone;

                _repositoryManager.Auditor.Update(auditor);
                await _repositoryManager.SaveAsync();
                return true;
            }
            catch (Exception e)
            {
                //_logger.LogError(e,"Error while updating Auditor with Id {Id}. Name: {Name}, Email: {Email}", id, dto.Name, dto.Email);
                throw; 
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            try {
                var auditor = await _repositoryManager.Auditor.GetByIdAsync(id);
                if (auditor is null)
                {
                    //_logger.LogWarning("Attempted to delete Auditor with Id {Id}, but it was not found.", id);
                    return false;
                }
                _repositoryManager.Auditor.Delete(auditor);
                await _repositoryManager.SaveAsync();

                return true;
            }
            catch(Exception e)
            {
                //_logger.LogError(e, "Error while deleting Auditor with Id {Id}.", id);
                throw;
            }
            
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

using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using Services.IRepositories;
using Services.IServices.Pharma_RM;
using Mapster;
using Microsoft.Extensions.Logging;
public class AuditTypeService : IAuditTypeService
{
    private readonly IRepositoryManager _repository;
    //private readonly ILogger<AuditTypeService> _logger;

    public AuditTypeService(IRepositoryManager repository)
    {
        _repository = repository;
       // _logger = logger;
    }

    public async Task<IEnumerable<AuditTypeDto>> GetAllAsync()
    {
        try
        {
            var entities = await _repository.AuditType.GetAllAsync();
            return entities.Adapt<IEnumerable<AuditTypeDto>>();
        }
        catch(Exception e)
        {
           // _logger.LogError("Error which fetching Audit Type");
            throw;
        }
        
    }

    public async Task<AuditTypeDto?> GetByIdAsync(int id)
    {
        try {
            var entity = await _repository.AuditType.GetByIdAsync(id);
            return entity?.Adapt<AuditTypeDto>();
        }
        catch(Exception e)
        {
            //_logger.LogError("Error which fetching Audit Type by Id.");
            throw;
        }
    }

    public async Task<AuditTypeDto> CreateAsync(AuditTypeForCreationDto dto)
    {
        try
        {
            var entity = dto.Adapt<AuditTypeMaster>();
            await _repository.AuditType.CreateAsync(entity);
            await _repository.SaveAsync();
            return entity.Adapt<AuditTypeDto>();
        }
        catch(Exception e)
        {
            //_logger.LogError(e, "Error while creating AuditType");
            throw;
        }
        
    }

    public async Task<bool> UpdateAsync(int id, AuditTypeForUpdateDto dto)
    {
        try
        {
            var entity = await _repository.AuditType.GetByIdAsync(id);
            if (entity == null)
            {
               // _logger.LogWarning("AuditType with Id {Id} not found for update.", id);
                return false;
            }
            dto.Adapt(entity); // maps dto values onto existing entity
            _repository.AuditType.Update(entity);
            await _repository.SaveAsync();
            return true;
        }
        catch(Exception e)
        {
            //_logger.LogError(e,"Error while updating AuditType with Id {Id}.", id);
            throw;
        }
       
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.AuditType.GetByIdAsync(id);
        if (entity == null) return false;

        _repository.AuditType.Delete(entity);
        await _repository.SaveAsync();
        return true;
    }
}

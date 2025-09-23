using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using Services.IRepositories;
using Services.IServices.Pharma_RM;
using Mapster;
public class AuditTypeService : IAuditTypeService
{
    private readonly IRepositoryManager _repository;

    public AuditTypeService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AuditTypeDto>> GetAllAsync()
    {
        var entities = await _repository.AuditType.GetAllAsync();
        return entities.Adapt<IEnumerable<AuditTypeDto>>();
    }

    public async Task<AuditTypeDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.AuditType.GetByIdAsync(id);
        return entity?.Adapt<AuditTypeDto>();
    }

    public async Task<AuditTypeDto> CreateAsync(AuditTypeForCreationDto dto)
    {
        var entity = dto.Adapt<AuditTypeMaster>();
        await _repository.AuditType.CreateAsync(entity);
        await _repository.SaveAsync();
        return entity.Adapt<AuditTypeDto>();
    }

    public async Task<bool> UpdateAsync(int id, AuditTypeForUpdateDto dto)
    {
        var entity = await _repository.AuditType.GetByIdAsync(id);
        if (entity == null) return false;

        dto.Adapt(entity); // maps dto values onto existing entity
        _repository.AuditType.Update(entity);
        await _repository.SaveAsync();
        return true;
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

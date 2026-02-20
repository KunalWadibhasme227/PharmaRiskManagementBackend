using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using Services.IRepositories;
using Services.IServices.Pharma_RM;
using Mapster;


public class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repository;

    public CategoryService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        try
        {
            var entities = await _repository.Category.GetAllAsync();
            return entities.Adapt<IEnumerable<CategoryDto>>();
        }
        catch (Exception e)
        {
            throw;
        }

    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _repository.Category.GetByIdAsync(id);
            return entity?.Adapt<CategoryDto>();
        }
        catch (Exception e)
        {
            //_logger.LogError("Error which fetching Audit Type by Id.");
            throw;
        }
    }

    public async Task<CategoryDto> CreateAsync(CategoryForCreationDto dto)
    {
        try
        {
            var entity = dto.Adapt<CategoryMaster>();
            await _repository.Category.CreateAsync(entity);
            await _repository.SaveAsync();
            return entity.Adapt<CategoryDto>();
        }
        catch (Exception e)
        {
            //_logger.LogError(e, "Error while creating AuditType");
            throw;
        }

    }

    public async Task<bool> UpdateAsync(int id, CategoryForUpdateDto dto)
    {
        try
        {
            var entity = await _repository.Category.GetByIdAsync(id);
            if (entity == null)
            {
               return false;
            }
            dto.Adapt(entity); // maps dto values onto existing entity
            _repository.Category.Update(entity);
            await _repository.SaveAsync();
            return true;
        }
        catch (Exception e)
        {
           throw;
        }

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.Category.GetByIdAsync(id);
        if (entity == null) return false;

        _repository.Category.Delete(entity);
        await _repository.SaveAsync();
        return true;
    }
}


using Common.Models.Dtos.Pharma_RM.MaterialFolder;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.Services.Pharma_RM;

namespace WebApi.Controllers.Pharma_RM.MaterialFolder
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MaterialController(IServiceManager service)
        {
            _service = service;
        }
         [HttpPost("GetMaterial")]
        public async Task<IActionResult> GetAll(MaterialRequestDto materialRequestDto)
        {
            var result = await _service.MaterialService.GetAllAsync(materialRequestDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.MaterialService.GetByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMaterialDto dto)
        {
            var result = await _service.MaterialService.AddAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, AddMaterialDto dto)
        {
            var result = await _service.MaterialService.UpdateAsync(id, dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{MatId}")]
        public async Task<IActionResult> Delete(Guid MatId)
        {
            var result = await _service.MaterialService.DeleteAsync(MatId);
            return StatusCode(result.StatusCode, result);
        }
    }    
}

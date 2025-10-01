using Common.Models.Dtos.Pharma_RM;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace WebApi.Controllers.Pharma_RM.MasterFolders
{
    [ApiController]
    [ApiVersion("1.0")]
    public class MasterCategory(IServiceManager service,
      ILogger<MasterCategory> logger): BaseApiController
    {
        private readonly IServiceManager _service = service;
        private readonly ILogger<MasterCategory> _logger = logger;


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.CategoryService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.CategoryService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryForCreationDto dto)
        {

            var result = await _service.CategoryService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.CategoryId }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryForUpdateDto dto)
        {

            var success = await _service.CategoryService.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.CategoryService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }

}

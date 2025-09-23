using Common.Models.Dtos.Pharma_RM;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    public class MasterAuditType(
     IServiceManager service,
     ILogger<MasterAuditType> logger,
     IValidator<AuditTypeForCreationDto> createValidator,
     IValidator<AuditTypeForUpdateDto> updateValidator)
     : BaseApiController
    {
        private readonly IServiceManager _service = service;
        private readonly ILogger<MasterAuditType> _logger = logger;
        private readonly IValidator<AuditTypeForCreationDto> _createValidator = createValidator;
        private readonly IValidator<AuditTypeForUpdateDto> _updateValidator = updateValidator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.AuditTypeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.AuditTypeService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuditTypeForCreationDto dto)
        {
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var result = await _service.AuditTypeService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.AuditTypeId }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AuditTypeForUpdateDto dto)
        {
            var validation = await _updateValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var success = await _service.AuditTypeService.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.AuditTypeService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }

}

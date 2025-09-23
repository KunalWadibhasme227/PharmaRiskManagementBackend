using Common.Models.Dtos.Pharma_RM;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    public class MasterAuditor(
     IServiceManager service,
     ILogger<MasterAuditor> logger,
     IValidator<AuditorForCreationDto> createValidator,
     IValidator<AuditorForUpdateDto> updateValidator)
     : BaseApiController
    {
        private readonly IServiceManager _service = service;
        private readonly ILogger<MasterAuditor> _logger = logger;
        private readonly IValidator<AuditorForCreationDto> _createValidator = createValidator;
        private readonly IValidator<AuditorForUpdateDto> _updateValidator = updateValidator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.AuditorService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.AuditorService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuditorForCreationDto dto)
        {
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var result = await _service.AuditorService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.AuditorId }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AuditorForUpdateDto dto)
        {
            var validation = await _updateValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var success = await _service.AuditorService.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.AuditorService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}

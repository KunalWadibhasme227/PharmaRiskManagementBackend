using Common.Models.Dtos.Pharma_RM;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.IServices.Pharma_RM;

namespace WebApi.Controllers.Pharma_RM.AuditFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuditController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditDto>>> GetAll()
        {
            return Ok(await _service.AuditService.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AuditDto>> GetById(Guid id)
        {
            var audit = await _service.AuditService.GetByIdAsync(id);
            if (audit == null) return NotFound();
            return Ok(audit);
        }

        [HttpPost]
        public async Task<ActionResult<AuditDto>> Create([FromBody] AuditCreateDto dto)
        {
            var created = await _service.AuditService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.AuditId }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AuditUpdateDto dto)
        {
            if (id != dto.AuditId) return BadRequest("ID mismatch");

            var success = await _service.AuditService.UpdateAsync(dto);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.AuditService.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}

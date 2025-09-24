using Common.Models.Dtos.Pharma_RM;
using Microsoft.AspNetCore.Mvc;
using Services.IServices.Pharma_RM;

namespace WebApi.Controllers.Pharma_RM.AuditFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IAuditService _auditService;

        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditDto>>> GetAll()
        {
            return Ok(await _auditService.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AuditDto>> GetById(Guid id)
        {
            var audit = await _auditService.GetByIdAsync(id);
            if (audit == null) return NotFound();
            return Ok(audit);
        }

        [HttpPost]
        public async Task<ActionResult<AuditDto>> Create([FromBody] AuditCreateDto dto)
        {
            var created = await _auditService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.AuditId }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AuditUpdateDto dto)
        {
            if (id != dto.AuditId) return BadRequest("ID mismatch");

            var success = await _auditService.UpdateAsync(dto);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _auditService.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}

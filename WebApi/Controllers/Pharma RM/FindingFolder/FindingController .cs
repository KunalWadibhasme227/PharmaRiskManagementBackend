using Common.Models.Dtos.Pharma_RM.FindingFolder;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace WebApi.Controllers.Pharma_RM.FindingFolder
{
    [ApiController]
    [Route("api/[controller]")]
    public class FindingController : ControllerBase
    {
        private readonly IServiceManager _service;

        public FindingController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filter)
        {
            var result = await _service.FindingService.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.FindingService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("By/{findingId:Guid}")]
        public async Task<IActionResult> GetByFindingId(Guid findingId)
        {
            var result = await _service.FindingService.GetByFindingIdAsync(findingId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FindingForCreateDto dto)
        {
            var result = await _service.FindingService.CreateAsync(dto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("updateProgres")]
        public async Task<IActionResult> Update( [FromBody] FindingForUpdateDto dto)
        {
            await _service.FindingService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.FindingService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("findingSummary")]
        public async Task<IActionResult> GetFindingSummary()
        {
            var result = await _service.FindingService.GetSummaryCountsAsync();
            return Ok(result);
        }

    }
}

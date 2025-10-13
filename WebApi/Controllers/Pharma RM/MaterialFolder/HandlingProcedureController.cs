using Common.Models.Dtos.Pharma_RM.MaterialFolder;
using Domain.Entities.Pharma_RM.Material;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace WebApi.Controllers.Pharma_RM.MaterialFolder
{
    [ApiController]
    [Route("api/[controller]")]
    public class HandlingProcedureController : ControllerBase
    {
        private readonly IServiceManager _service;

        public HandlingProcedureController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.HandlingProcedure.GetAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.HandlingProcedure.GetByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HandlingProcedureDto dto)
        {
            var result = await _service.HandlingProcedure.AddAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, HandlingProcedure dto)
        {
            var result = await _service.HandlingProcedure.UpdateAsync(id, dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _service.HandlingProcedure.DeleteAsync(Id);
            return StatusCode(result.StatusCode, result);
        }
    }
}

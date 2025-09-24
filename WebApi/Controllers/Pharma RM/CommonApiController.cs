using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using System.Reflection.Metadata.Ecma335;

namespace WebApi.Controllers.Pharma_RM
{
    [ApiController]
    [ApiVersion("1.0")]
    public class CommonApiController(IServiceManager service) : BaseApiController
    {
        private readonly IServiceManager _service = service;

        [HttpGet("states")]
        public async Task<IActionResult> GetAllState()
        {
            var result = await _service.CommonService.GetAllStateAsync();
            return Ok(result);
        }

        [HttpGet("GetCitiesByStateId/{Id}")]
        public async Task<IActionResult> GetCitiesByStateId(int Id)
        {
            var result = await _service.CommonService.GetAllCitiesAsync(Id);
            return Ok(result);
        }
        
    }
}

using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace WebApi.Controllers.Pharma_RM
{
    [ApiController]
    [ApiVersion("1.0")]
    public class CommonApiController(IServiceManager service) : BaseApiController
    {
        private readonly IServiceManager _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllState()
        {
            var result = await _service.CommonService.GetAllStateAsync();
            return Ok(result);
        }
        
    }
}

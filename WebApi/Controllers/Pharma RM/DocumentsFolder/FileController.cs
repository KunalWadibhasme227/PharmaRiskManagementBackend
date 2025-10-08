using Common.Models.Dtos.Pharma_RM.Documents;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.IServices.Pharma_RM;
using Services.Services.Pharma_RM;

namespace WebApi.Controllers.Pharma_RM.DocumentsFolder
{
    [Route("api/[controller]")]
    [ApiController]

    public class FileController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;

        public FileController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        [HttpPost("upload/{documentType}")]
        [ProducesResponseType(typeof(FileResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromRoute] string documentType)
        {
            try
            {
                // Delegate the core logic (validation, I/O) to the service layer
                var response = await _fileUploadService.UploadFileAsync(file, documentType);

                // The service handles the null/empty check and throws an ArgumentException, which we catch.
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., using a logger)
                return StatusCode(500, $"Internal server error during file upload: {ex.Message}");
            }
        }
    }


}

using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using Microsoft.AspNetCore.Mvc;
using Services.IServices.Pharma_RM;

namespace WebApi.Controllers.Pharma_RM.DocumentsFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadDocumentsController : ControllerBase
    {
        private readonly IUploadDocumentService _documentService;

        public UploadDocumentsController(IUploadDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] UploadDocumentFormModel model)
        {
            if (model.File == null || model.File.Length == 0)
                return BadRequest("File is required for document creation.");

            // Map form data to DTO
            var dto = new UploadDocumentCreationDto
            {
                DocumentName = model.DocumentName!,
                CategoryId = model.CategoryId,
                Audit = model.Audit,
                Description = model.Description,
                CreatedDate = model.CreatedDate,
                ExpiryDate = model.ExpiryDate,
                Version = "v1",
                Status = "Pending"
            };

            var newDocument = await _documentService.CreateAsync(dto, model.File);

            return CreatedAtAction(nameof(GetById), new { documentId = newDocument.DocumentId }, newDocument);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UploadDocumentDto>>> GetAll()
        {
            var documents = await _documentService.GetAllAsync();
            return Ok(documents);
        }

        [HttpGet("{documentId}")]
        public async Task<ActionResult<UploadDocumentDto>> GetById(int documentId)
        {
            var document = await _documentService.GetByIdAsync(documentId);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpPut("{documentId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(int documentId, [FromForm] UploadDocumentUpdateFormModel model)
        {
            var dto = new UploadDocumentUpdateDto
            {
                DocumentName = model.DocumentName,
                CategoryId = model.CategoryId,
                Audit = model.Audit,
                Description = model.Description,
                ExpiryDate = model.ExpiryDate
            };

            var updatedDocument = await _documentService.UpdateAsync(documentId, dto, model.File);
            if (updatedDocument == null)
                return NotFound($"Document with ID {documentId} not found.");

            return Ok(updatedDocument);
        }

        [HttpDelete("{documentId}")]
        public async Task<IActionResult> Delete(int documentId)
        {
            await _documentService.DeleteAsync(documentId);
            return NoContent();
        }

        [HttpGet("Download/{documentId}")]
        public async Task<IActionResult> Download(int documentId)
        {
            var fileData = await _documentService.DownloadAsync(documentId);

            if (fileData == null)
                return NotFound("File not found.");

            return File(fileData.FileContent, fileData.ContentType, fileData.FileName);
        }

        [HttpGet("ViewDetails/{documentId}")]
        public async Task<ActionResult<UploadDocumentDto>> ViewDetails(int documentId)
        {
            var document = await _documentService.ViewDetailsAsync(documentId);
            if (document == null)
                return NotFound($"Document with ID {documentId} not found.");

            return Ok(document);
        }



    }
}

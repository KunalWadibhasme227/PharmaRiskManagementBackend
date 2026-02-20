using Common.Models.Dtos.Pharma_RM.Documents;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SendGrid;
using Services.IServices;

namespace WebApi.Controllers.Pharma_RM.DocumentsFolder
{
        [Route("api/[controller]")]
        [ApiController]
        public class DocumentsController : ControllerBase
        {
            private readonly IServiceManager _serviceManager;

            // Inject the Service Manager to access all document-related services
            public DocumentsController(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }

            // GET /api/documents/dashboard
            [HttpGet("dashboard")]
            [ProducesResponseType(typeof(DashboardDataDto), 200)]
            public async Task<IActionResult> GetDashboardData()
            {
                var dashboardData = await _serviceManager.DocumentService.GetDashboardDataAsync();
                return Ok(dashboardData);
            }

            /// <summary>
            /// Saves the document metadata after the file has been successfully uploaded.
            /// This is the SECOND step of document creation.
            /// </summary>
            // POST /api/documents/new
            [HttpPost("new")]
            [ProducesResponseType(typeof(int), 201)]
            [ProducesResponseType(400)]
            [ProducesResponseType(500)]
            public async Task<IActionResult> SaveNewDocument([FromBody] NewDocumentDto documentData)
            {
                try
                {
                    // Assuming the authenticated user ID is obtained here (e.g., from JWT token claims)
                    // Placeholder for User ID
                    string userId = "current.user.id";

                    int newDocumentId = await _serviceManager.DocumentService.SaveNewDocumentAsync(documentData, userId);

                    // Return 201 Created with the location of the new resource
                    return CreatedAtAction(nameof(GetDocument), new { id = newDocumentId }, newDocumentId);
                }
                catch (InvalidOperationException ex)
                {
                    // Catches missing global code errors (DRAFT status, UPLOAD action, etc.)
                    return BadRequest($"Configuration Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error while saving document metadata: {ex.Message}");
                }
            }

            // GET /api/documents/{id}
            [HttpGet("{id}")]
            [ProducesResponseType(200)]
            [ProducesResponseType(404)]
            public async Task<IActionResult> GetDocument(int id)
            {
                var document = await _serviceManager.DocumentService.GetDocumentAsync(id);
                if (document == null)
                {
                    return NotFound();
                }
                return Ok(document);
            }

            // PUT /api/documents/workflow/{documentId}
            [HttpPut("workflow/{documentId}")]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]
            [ProducesResponseType(404)]
            public async Task<IActionResult> UpdateDocumentWorkflow(int documentId, [FromBody] WorkflowUpdateDto updateDto)
            {
                try
                {
                    // Placeholder for User ID
                    string actionByUserId = "current.user.id";

                    await _serviceManager.DocumentService.UpdateDocumentWorkflowAsync(documentId, updateDto, actionByUserId);

                    return Ok(new { message = $"Document {documentId} workflow updated successfully." });
                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {
                    // For permission/authorization failures (e.g., user can't perform the transition)
                    return Forbid(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    // For invalid stage transition logic
                    return BadRequest(ex.Message);
                }
            }

            // GET /api/documents/{id}/download
            [HttpGet("{id}/download")]
            [ProducesResponseType(typeof(FileContentResult), 200)]
            [ProducesResponseType(404)]
            [ProducesResponseType(403)]
            public async Task<IActionResult> DownloadDocument(int id)
            {
                // Placeholder for User ID
                string userId = "current.user.id";

                try
                {
                    // Delegate file path lookup and authorization check to the service
                    var (absolutePath, fileName) = await _serviceManager.DocumentService.GetDownloadInfoAsync(id, userId);

                    if (!System.IO.File.Exists(absolutePath))
                    {
                        // This means the metadata is in the DB but the file is missing on disk
                        return NotFound("The file content for this document was not found on the server.");
                    }

                    var fileBytes = await System.IO.File.ReadAllBytesAsync(absolutePath);
                    var contentType = MimeTypes.GetMimeType(Path.GetExtension(fileName));
                    //var contentType = MimeTypeMap.List.MimeTypeMap.GetMimeType(Path.GetExtension(fileName));

                    // Return the file stream
                    return File(fileBytes, contentType, fileName);
                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {
                    return Forbid(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error during file download: {ex.Message}");
                }
            }
        }
}

using Common.Models.Dtos.Pharma_RM.Documents;
using Domain.Entities.Pharma_RM;
using Services.IRepositories;
using Services.IServices.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Pharma_RM
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepositoryManager _repoManager;
        // private readonly IMapper _mapper; // Use Mapster/AutoMapper for entity/dto conversion

        public DocumentService(IRepositoryManager repoManager /*, IMapper mapper */)
        {
            _repoManager = repoManager;
            // _mapper = mapper;
        }

        public async Task<DashboardDataDto> GetDashboardDataAsync()
        {
            // Call repository for complex SP/query execution
            var rawData = await _repoManager.Document.GetDashboardDataFromDbAsync();
            // Map rawData to DashboardDataDto
            // return _mapper.Map<DashboardDataDto>(rawData);
            return new DashboardDataDto(); // Placeholder
        }

        public async Task<int> SaveNewDocumentAsync(NewDocumentDto documentData, string createdByUserId)
        {
            // 1. Get initial status ID (e.g., 'DRAFT') and initial stage ID ('DRAFT_CREATE')
            int draftStatusCodeId = await _repoManager.GlobalDocument.GetCodeIdByValueAsync("STATUS", "DRAFT")
                                     ?? throw new InvalidOperationException("Missing DRAFT status code.");
            int draftStageCodeId = await _repoManager.GlobalDocument.GetCodeIdByValueAsync("DOC_STAGE", "DRAFT_CREATE")
                                    ?? throw new InvalidOperationException("Missing DRAFT_CREATE stage code.");
            int uploadActionCodeId = await _repoManager.GlobalDocument.GetCodeIdByValueAsync("DOC_ACTION", "UPLOAD")
                                     ?? throw new InvalidOperationException("Missing UPLOAD action code.");

            // 2. Map DTO to Entity and set initial state
            var newDocument = new Document
            {
                DocumentTitle = documentData.Title,
                CategoryDocumentsId = documentData.CategoryDocumentsId,
                FilePath = documentData.RelativeFilePath,
                ReviewDueDate = documentData.ReviewDueDate,
                StatusCodeId = draftStatusCodeId, // Set status to DRAFT
                VersionNumber = "1.0",
                IsLatestVersion = true,
                CreatedDate = DateTime.UtcNow
            };

            // 3. Document Insert (Repository handles the actual DB transaction)
            int documentId = await _repoManager.Document.CreateDocumentAsync(newDocument);

            // 4. Initialize Document Workflow
            var initialWorkflow = new DocumentWorkflow
            {
                DocumentId = documentId,
                StageCodeId = draftStageCodeId, // Set stage to DRAFT_CREATE
                AssignedTo = createdByUserId,
                DocCount = 1
            };
            // Note: Workflow/Log inserts would typically be handled by specialized repository methods,
            // or implicitly via EF Core tracking if handled transactionally in the repository manager.

            // 5. Log the initial action
            var uploadLog = new DocumentActionLog
            {
                DocumentId = documentId,
                ActionTypeCodeId = uploadActionCodeId,
                ActionBy = createdByUserId,
                Notes = $"Document uploaded and metadata saved by user {createdByUserId}."
            };

            // In a real scenario, all 3 inserts (Doc, Workflow, Log) occur inside a single transaction
            // controlled by IRepositoryManager.SaveAsync().

            await _repoManager.SaveAsync(); // Commit the Unit of Work

            return documentId;
        }

        public Task UpdateDocumentWorkflowAsync(int documentId, WorkflowUpdateDto updateDto, string actionByUserId)
        {
            // 1. Fetch current DocumentWorkflow record
            // 2. Validate stage transition rules (business logic)
            // 3. Update DocumentWorkflow with NewStageCodeId and AssignedTo
            // 4. Insert into DocumentActionLog
            // 5. SaveAsync()
            return Task.CompletedTask;
        }

        public async Task<(string absolutePath, string fileName)> GetDownloadInfoAsync(int documentId, string userId) // <-- Note: Return type element names updated
        {
            // 1. Fetch Document entity
            var document = await _repoManager.Document.GetDocumentByIdAsync(documentId);

            if (document == null || string.IsNullOrEmpty(document.FilePath))
                throw new KeyNotFoundException($"Document with ID {documentId} not found or has no file path.");

            // 2. Perform Authorization Check (Business Logic)
            // ...

            // 3. Combine wwwroot path with relative path
            // You already use absolutePath for the local variable name, which is good.
            var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", document.FilePath.TrimStart('/'));

            // Fix: Ensure the returned tuple elements match the interface names (absolutePath and fileName)
            return (absolutePath: absolutePath, fileName: document.DocumentTitle);
        }

        public Task<object> GetDocumentAsync(int id)
        {
            // Fetch Document (with includes for Category/Status/Workflow) and map to DTO
            return Task.FromResult<object>(new { id, Title = "Sample Document" }); // Placeholder
        }
    }
}

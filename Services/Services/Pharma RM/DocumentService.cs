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
        
        public DocumentService(IRepositoryManager repoManager )
        {
            _repoManager = repoManager;
        }

        public async Task<DashboardDataDto> GetDashboardDataAsync()
        {
            var rawData = await _repoManager.Document.GetDashboardDataFromDbAsync();
           
            return new DashboardDataDto(); 
        }

        public async Task<int> SaveNewDocumentAsync(NewDocumentDto documentData, string createdByUserId)
        {
            
            int draftStatusCodeId = await _repoManager.GlobalDocument.GetCodeIdByValueAsync("STATUS", "DRAFT")
                                     ?? throw new InvalidOperationException("Missing DRAFT status code.");
            int draftStageCodeId = await _repoManager.GlobalDocument.GetCodeIdByValueAsync("DOC_STAGE", "DRAFT_CREATE")
                                    ?? throw new InvalidOperationException("Missing DRAFT_CREATE stage code.");
            int uploadActionCodeId = await _repoManager.GlobalDocument.GetCodeIdByValueAsync("DOC_ACTION", "UPLOAD")
                                     ?? throw new InvalidOperationException("Missing UPLOAD action code.");

            
            var newDocument = new Document
            {
                DocumentTitle = documentData.Title,
                CategoryDocumentsId = documentData.CategoryDocumentsId,
                FilePath = documentData.RelativeFilePath,
                ReviewDueDate = documentData.ReviewDueDate,
                StatusCodeId = draftStatusCodeId,
                VersionNumber = "1.0",
                IsLatestVersion = true,
                CreatedDate = DateTime.UtcNow
            };

            
            int documentId = await _repoManager.Document.CreateDocumentAsync(newDocument);

            var initialWorkflow = new DocumentWorkflow
            {
                DocumentId = documentId,
                StageCodeId = draftStageCodeId,
                AssignedTo = createdByUserId,
                DocCount = 1
            };
           
            var uploadLog = new DocumentActionLog
            {
                DocumentId = documentId,
                ActionTypeCodeId = uploadActionCodeId,
                ActionBy = createdByUserId,
                Notes = $"Document uploaded and metadata saved by user {createdByUserId}."
            };

            
            await _repoManager.SaveAsync(); 

            return documentId;
        }

        public Task UpdateDocumentWorkflowAsync(int documentId, WorkflowUpdateDto updateDto, string actionByUserId)
        {
           
            return Task.CompletedTask;
        }

        public async Task<(string absolutePath, string fileName)> GetDownloadInfoAsync(int documentId, string userId) // <-- Note: Return type element names updated
        {
          
            var document = await _repoManager.Document.GetDocumentByIdAsync(documentId);

            if (document == null || string.IsNullOrEmpty(document.FilePath))
                throw new KeyNotFoundException($"Document with ID {documentId} not found or has no file path.");

            var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", document.FilePath.TrimStart('/'));

            
            return (absolutePath: absolutePath, fileName: document.DocumentTitle);
        }

        public Task<object> GetDocumentAsync(int id)
        {
            
            return Task.FromResult<object>(new { id, Title = "Sample Document" }); 
        }
    }
}

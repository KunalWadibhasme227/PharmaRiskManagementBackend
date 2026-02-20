using Common.Models.Dtos.Pharma_RM.Documents;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Pharma_RM
{
    /// <summary>
    /// Defines the contract for handling file storage operations, keeping them isolated from the controller.
    /// </summary>
    public interface IDocumentService
    {
        Task<DashboardDataDto> GetDashboardDataAsync();
        Task<int> SaveNewDocumentAsync(NewDocumentDto documentData, string userId);
        Task<object> GetDocumentAsync(int id);
        Task UpdateDocumentWorkflowAsync(int documentId, WorkflowUpdateDto updateDto, string userId);
        Task<(string absolutePath, string fileName)> GetDownloadInfoAsync(int id, string userId);

    }
}

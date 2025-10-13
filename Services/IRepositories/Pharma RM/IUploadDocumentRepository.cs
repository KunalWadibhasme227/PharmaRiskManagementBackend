using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositories.Pharma_RM
{
    public interface IUploadDocumentRepository
    {
        Task<PagedUploadDocumentDto> GetAllAsync(UploadDocumentRequestDto document);
        Task<int> CreateAsync(UploadDocument document);
        Task<UploadDocument?> GetByIdAsync(int documentId);
        Task<bool> UpdateAsync(UploadDocument document);
        Task<bool> DeleteAsync(int documentId);
        Task<string> GetCurrentVersionAsync(int documentId);
    }
}

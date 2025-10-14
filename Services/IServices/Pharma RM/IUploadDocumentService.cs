using Common.Models.Dtos.Pharma_RM;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Pharma_RM
{
    public interface IUploadDocumentService
    {
        Task<PagedUploadDocumentDto> GetAllAsync(UploadDocumentRequestDto document);
        Task<UploadDocumentDto> CreateAsync(UploadDocumentCreationDto dto, IFormFile file);
        Task<UploadDocumentDto?> UpdateAsync(int documentId, UploadDocumentUpdateDto dto, IFormFile? file);
        Task<UploadDocumentDto?> GetByIdAsync(int documentId);
        Task<FileDownloadDto?> DownloadAsync(int documentId);
        Task<UploadDocumentDto?> ViewDetailsAsync(int documentId);
        string UploadDirectory { get; }
        Task DeleteAsync(int documentId);
    }
}

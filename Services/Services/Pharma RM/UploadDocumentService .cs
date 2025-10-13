using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using Mapster;
using Microsoft.AspNetCore.Http;
using Services.IRepositories;
using Services.IServices.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Pharma_RM
{
    public class UploadDocumentService : IUploadDocumentService
    {
        private readonly IRepositoryManager _repository;
        private readonly IFileUploadService _fileService;

        private const string DocumentType = "uploads";

        public UploadDocumentService(
            IRepositoryManager repository,
            IFileUploadService fileService)
        {
            _repository = repository;
            _fileService = fileService;

        }


        public async Task<UploadDocumentDto> CreateAsync(UploadDocumentCreationDto dto, IFormFile file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));

            var fileResponse = await _fileService.UploadFileAsync(file, DocumentType);

            var document = dto.Adapt<UploadDocument>();

            document.CreatedDate = DateTime.UtcNow; ;
            document.IsDeleted = false;
            document.FilePath = fileResponse.RelativeFilePath;
            document.FileSizeKB = (int)(file.Length / 1024);
            document.Status = "Pending";
            document.Version = "v1";

            int newId = await _repository.UploadDocument.CreateAsync(document);
            document.DocumentId = newId;
            await _repository.SaveAsync();

            var documentDto = document.Adapt<UploadDocumentDto>();

            var category = await _repository.Category.GetByIdAsync(document.CategoryId);
            documentDto.CategoryName = category?.CategoryName;

            return documentDto;
        }

        public async Task<UploadDocumentDto?> GetByIdAsync(int documentId)
        {
            var entity = await _repository.UploadDocument.GetByIdAsync(documentId);
            if (entity == null) return null;

            var dto = entity.Adapt<UploadDocumentDto>();

            var category = await _repository.Category.GetByIdAsync(entity.CategoryId);
            dto.CategoryName = category?.CategoryName;

            return dto;
        }
        
        public async Task<PagedUploadDocumentDto> GetAllAsync(UploadDocumentRequestDto document)
        {
            try
            {
                var documents = await _repository.UploadDocument.GetAllAsync(document);
                return documents.Adapt<PagedUploadDocumentDto>();
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<UploadDocumentDto?> UpdateAsync(int documentId, UploadDocumentUpdateDto dto, IFormFile? file)
        {
            var existingDoc = await _repository.UploadDocument.GetByIdAsync(documentId);
            if (existingDoc == null) return null;

            dto.Adapt(existingDoc);

            if (file != null)
            {
                string versionStr = existingDoc.Version.TrimStart('v');
                if (int.TryParse(versionStr, out int versionNum))
                {
                    existingDoc.Version = $"v{versionNum + 1}";
                }

                var fileResponse = await _fileService.UploadFileAsync(file, DocumentType);
                existingDoc.FilePath = fileResponse.RelativeFilePath;
                existingDoc.FileSizeKB = (int)(file.Length / 1024);
            }

            await _repository.UploadDocument.UpdateAsync(existingDoc);
            await _repository.SaveAsync();

            var updatedDto = existingDoc.Adapt<UploadDocumentDto>();

            var category = await _repository.Category.GetByIdAsync(existingDoc.CategoryId);
            updatedDto.CategoryName = category?.CategoryName;

            return updatedDto;
        }

        public async Task DeleteAsync(int documentId)
        {
            try
            {
                var entity = await _repository.UploadDocument.GetByIdAsync(documentId);
                if (entity == null) return;

                // Optional: Delete physical file first
                // if (!string.IsNullOrEmpty(entity.FilePath))
                // {
                //     // You need a delete method in your IFileUploadService
                //     // _fileService.DeleteFile(entity.FilePath); 
                // }

                await _repository.UploadDocument.DeleteAsync(documentId);
                await _repository.SaveAsync();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<FileDownloadDto?> DownloadAsync(int documentId)
        {
            var document = await _repository.UploadDocument.GetByIdAsync(documentId);
            if (document == null || string.IsNullOrEmpty(document.FilePath))
                return null;

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", document.FilePath.TrimStart('/', '\\'));

            if (!File.Exists(filePath))
                return null;

            var fileBytes = await File.ReadAllBytesAsync(filePath);

            return new FileDownloadDto
            {
                FileContent = fileBytes,
                FileName = Path.GetFileName(filePath),
                ContentType = GetContentType(filePath) 
            };
        }

        private string GetContentType(string path)
        {
            var types = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            { ".txt", "text/plain" },
            { ".pdf", "application/pdf" },
            { ".doc", "application/msword" },
            { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { ".xls", "application/vnd.ms-excel" },
            { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
            { ".png", "image/png" },
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".gif", "image/gif" }
        };

            var ext = Path.GetExtension(path);
            return types.TryGetValue(ext, out var contentType) ? contentType : "application/octet-stream";
        }

        public async Task<UploadDocumentDto?> ViewDetailsAsync(int documentId)
        {
            var document = await _repository.UploadDocument.GetByIdAsync(documentId);
            if (document == null) return null;

            var category = await _repository.Category.GetByIdAsync(document.CategoryId);

            var dto = document.Adapt<UploadDocumentDto>();
            dto.CategoryName = category?.CategoryName;

            return dto;
        }





    }
}

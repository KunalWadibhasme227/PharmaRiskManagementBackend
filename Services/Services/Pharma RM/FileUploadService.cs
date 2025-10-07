using Common.Models.Dtos.Pharma_RM.Documents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Services.IRepositories;
using Services.IServices.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Pharma_RM
{
    public class FileService : IFileUploadService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<FileResponseDto> UploadFileAsync(IFormFile file, string documentType)
        {

            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Upload failed: No file selected or file is empty.");
            }

            var safeDocumentType = documentType.ToLowerInvariant();
            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var folderName = $"files/{safeDocumentType}s";
            var uploadsFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", folderName);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var relativeFilePath = $"/{folderName}/{uniqueFileName}";

            return new FileResponseDto
            {
                Message = "File uploaded successfully. Use the relative path to save document metadata in the next step.",
                RelativeFilePath = relativeFilePath,
                OriginalFileName = file.FileName
            };
        }
    }
}
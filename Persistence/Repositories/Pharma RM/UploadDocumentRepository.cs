using Common.Models.Dtos.Pharma_RM;
using Dapper;
using Domain.Entities.Pharma_RM;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.IRepositories.Pharma_RM;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Persistence.Repositories.Pharma_RM
{
    public class UploadDocumentRepository : IUploadDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public UploadDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(UploadDocument document)
        {
            await _context.UploadDocuments.AddAsync(document);
            await _context.SaveChangesAsync();
            return document.DocumentId;
        }

        public async Task<PagedUploadDocumentDto> GetAllAsync(UploadDocumentRequestDto document)
        {
            using var connection = _context.Database.GetDbConnection();

            var UploadDocumentRecord = await connection.QueryAsync<UploadDocumentDto>(
                "dbo.GetUploadDocumentsList",
                new
                {
                    SearchText = document.SearchText,
                    PageNumber = document.PageNumber,
                    PageSize = document.PageSize
                },
                commandType: CommandType.StoredProcedure
            );

            var recordsList = UploadDocumentRecord.ToList();
            var totalCount = recordsList.FirstOrDefault()?.TotalCount ?? 0;

            return new PagedUploadDocumentDto
            {
                Records = recordsList.ToArray(),
                PageNumber = document.PageNumber,
                PageSize = document.PageSize,
                TotalCount = totalCount
            };
        }


        //public async Task<IEnumerable<UploadDocument>> GetAllAsync()
        //{
        //    return await _context.UploadDocuments
        //                         .AsNoTracking()
        //                         .Include(d => d.Category) // optional
        //                         .ToListAsync();
        //}

        public async Task<UploadDocument?> GetByIdAsync(int documentId)
        {
            return await _context.UploadDocuments
                                 .Include(d => d.Category)
                                 .FirstOrDefaultAsync(d => d.DocumentId == documentId);
        }

        public async Task<UploadDocument?> UpdateAsync(int documentId, UploadDocumentUpdateDto dto, IFormFile? file)
        {
            var existing = await _context.UploadDocuments.FindAsync(documentId);
            if (existing == null) return null;

            existing.DocumentName = dto.DocumentName;
            existing.CategoryId = dto.CategoryId;
            existing.AuditId = dto.AuditId;
            //existing.Audit = dto.Audit;
            existing.Description = dto.Description;
            existing.ExpiryDate = dto.ExpiryDate;

            if (file != null)
            {
                var filePath = await SaveFileAsync(file);
                existing.FilePath = filePath;
                existing.FileSizeKB = (int) file.Length / 1024; 
            }

            var versionNumber = int.TryParse(existing.Version?.TrimStart('v'), out var v) ? v + 1 : 1;
            existing.Version = "v" + versionNumber;

            _context.Update(existing);
            await _context.SaveChangesAsync();

            return existing;
        }

        // Example helper method
        private async Task<string> SaveFileAsync(IFormFile file)
        {
            var folder = Path.Combine("wwwroot", "files", "uploads");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(folder, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/files/uploads/{fileName}";
        }



        //public async Task<bool> UpdateAsync(UploadDocument document)
        //{
        //    var existing = await _context.UploadDocuments.FindAsync(document.DocumentId);
        //    if (existing == null) return false;

        //    _context.Entry(existing).CurrentValues.SetValues(document);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}

        public async Task<bool> DeleteAsync(int documentId)
        {
            var existing = await _context.UploadDocuments.FindAsync(documentId);
            if (existing == null) return false;

            _context.UploadDocuments.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string> GetCurrentVersionAsync(int documentId)
        {
            var doc = await _context.UploadDocuments
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(d => d.DocumentId == documentId);
            return doc?.Version ?? "v1";
        }
    }
}

using Common.Models.Dtos.Pharma_RM;
using Dapper;
using Domain.Entities.Pharma_RM;
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

        public async Task<bool> UpdateAsync(UploadDocument document)
        {
            var existing = await _context.UploadDocuments.FindAsync(document.DocumentId);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(document);
            await _context.SaveChangesAsync();
            return true;
        }

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

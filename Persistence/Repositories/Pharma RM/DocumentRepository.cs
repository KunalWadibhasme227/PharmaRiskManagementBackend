using Domain.Entities.Pharma_RM;
using Microsoft.EntityFrameworkCore;
using Services.IRepositories.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Pharma_RM
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Document?> GetDocumentByIdAsync(int id)
        {
            return await _context.Documents.Include(d => d.Status).FirstOrDefaultAsync(d => d.DocumentId == id);
        }

        public async Task<int> CreateDocumentAsync(Document document)
        {
            _context.Documents.Add(document);

            await _context.SaveChangesAsync(); 

            return document.DocumentId;
        }

        public Task UpdateDocumentAsync(Document document)
        {
            _context.Documents.Update(document);
            return Task.CompletedTask;
        }

        public Task<object> GetDashboardDataFromDbAsync()
        {
            
            return Task.FromResult<object>(new { Total = 100, Review = 5 }); 
        }
    }
}

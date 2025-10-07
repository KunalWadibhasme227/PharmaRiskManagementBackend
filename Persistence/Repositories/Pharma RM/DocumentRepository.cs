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
            // Workflow and ActionLog initial entries can be added here or in the Service/Transaction logic.
            // _context.DocumentWorkflows.Add(initialWorkflow);
            // _context.DocumentActionLogs.Add(uploadLog);
            await _context.SaveChangesAsync(); // Note: Save is called here or in RepositoryManager.SaveAsync()

            return document.DocumentId;
        }

        public Task UpdateDocumentAsync(Document document)
        {
            _context.Documents.Update(document);
            return Task.CompletedTask;
        }

        public Task<object> GetDashboardDataFromDbAsync()
        {
            // Dapper usage or EF Core FromSqlRaw to execute sp_GetDashboardData
            // Example: var data = await _context.Database.ExecuteSqlRawAsync("EXEC sp_GetDashboardData");
            return Task.FromResult<object>(new { Total = 100, Review = 5 }); // Placeholder
        }
    }
}

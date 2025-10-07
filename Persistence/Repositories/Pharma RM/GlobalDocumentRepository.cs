
using Domain.Entities.Pharma_RM;
using Microsoft.EntityFrameworkCore;
using Services.IRepositories.Pharma_RM;

namespace Persistence.Repositories.Pharma_RM
{
    public class GlobalDocumentRepository : IGlobalDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public GlobalDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MasterGlobalDocuments?> GetCodeByValueAsync(string documentType, string documentValue)
        {
            return await _context.MasterGlobalDocuments
                .FirstOrDefaultAsync(c => c.DocumentsType == documentType && c.DocumentsValue == documentValue && c.IsActive);
        }

        public async Task<int?> GetCodeIdByValueAsync(string documentType, string documentValue)
        {
            return await _context.MasterGlobalDocuments
                .Where(c => c.DocumentsType == documentType && c.DocumentsValue == documentValue && c.IsActive)
                .Select(c => c.GlobalDocumentsId)
                .FirstOrDefaultAsync();
        }
    }
}

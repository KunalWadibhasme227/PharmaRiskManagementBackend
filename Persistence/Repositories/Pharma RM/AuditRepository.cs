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
    public class AuditRepository : IAuditRepository
    {
        private readonly ApplicationDbContext _context;

        public AuditRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Audit>> GetAllAsync() 
        {
            return await _context.Audits.ToListAsync();
        }

        public async Task<Audit?> GetByIdAsync(Guid id)
        {
            return await _context.Audits.FindAsync(id);
        }

        public async Task CreateAsync(Audit audit)
        {
            await _context.Audits.AddAsync(audit);
        }

        public void Update(Audit audit)
        {
            _context.Audits.Update(audit);
        }

        public void Delete(Audit audit)
        {
            _context.Audits.Remove(audit);
        }
    }
}

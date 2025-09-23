using Domain.Entities.Pharma_RM;
using Microsoft.EntityFrameworkCore;
using Services.IRepositories.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Pharma
{
    public class AuditTypeRepository : IAuditTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public AuditTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuditTypeMaster>> GetAllAsync()
            => await _context.AuditTypeMasters.AsNoTracking().ToListAsync();

        public async Task<AuditTypeMaster?> GetByIdAsync(int id)
            => await _context.AuditTypeMasters.FindAsync(id);

        public async Task CreateAsync(AuditTypeMaster entity)
            => await _context.AuditTypeMasters.AddAsync(entity);

        public void Update(AuditTypeMaster entity)
            => _context.AuditTypeMasters.Update(entity);

        public void Delete(AuditTypeMaster entity)
            => _context.AuditTypeMasters.Remove(entity);
    }

}

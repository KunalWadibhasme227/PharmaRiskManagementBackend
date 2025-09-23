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
    public class AuditorRepository : IAuditorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuditorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Auditor>> GetAllAsync()
            => await _context.Auditors.AsNoTracking().ToListAsync();

        public async Task<Auditor?> GetByIdAsync(int id)
            => await _context.Auditors.FindAsync(id);

        public async Task CreateAsync(Auditor entity)
            => await _context.Auditors.AddAsync(entity);

        public void Update(Auditor entity)
            => _context.Auditors.Update(entity);

        public void Delete(Auditor entity)
            => _context.Auditors.Remove(entity);
    }
}

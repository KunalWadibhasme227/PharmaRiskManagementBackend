
using Persistence.Repositories.Pharma;
using Services.IRepositories;
using Services.IRepositories.Pharma_RM;
using System;

namespace Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IAuditTypeRepository> _auditTypeRepo;
        private readonly Lazy<IAuditorRepository> _auditorRepo;

        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _auditTypeRepo = new Lazy<IAuditTypeRepository>(() => new AuditTypeRepository(context));
            _auditorRepo = new Lazy<IAuditorRepository>(() => new AuditorRepository(context));
        }

        public IAuditTypeRepository AuditType => _auditTypeRepo.Value;
        public IAuditorRepository Auditor => _auditorRepo.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }

}

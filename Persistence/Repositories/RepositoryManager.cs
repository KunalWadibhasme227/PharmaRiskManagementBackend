
using Persistence.Repositories.Pharma;
using Persistence.Repositories.Pharma_RM;
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
        private readonly Lazy<IAuditRepository> _auditRepo;

        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _auditTypeRepo = new Lazy<IAuditTypeRepository>(() => new AuditTypeRepository(context));
            _auditorRepo = new Lazy<IAuditorRepository>(() => new AuditorRepository(context));
            _auditRepo = new Lazy<IAuditRepository>(() => new AuditRepository(context));
        }

        public IAuditTypeRepository AuditType => _auditTypeRepo.Value;
        public IAuditorRepository Auditor => _auditorRepo.Value;
        public IAuditRepository Audit => _auditRepo.Value;
        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }

}


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
        public readonly Lazy<IMasterGlobalCodeTypeRepository> _lazyIMasterGlobalCodeTypeRepository;
        private readonly Lazy<IMasterGlobalCodeRepository> _lazyIMasterGlobalCodeRepository;
        private readonly Lazy<ICommonApiRepository> _lazyCommonApiRepository;
        private readonly Lazy<IAuditRepository> _auditRepo;
        private readonly Lazy<IFindingRepository> _findingRepo;
        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _auditTypeRepo = new Lazy<IAuditTypeRepository>(() => new AuditTypeRepository(context));
            _auditorRepo = new Lazy<IAuditorRepository>(() => new AuditorRepository(context));
             _lazyIMasterGlobalCodeTypeRepository = new Lazy<IMasterGlobalCodeTypeRepository>(() => new MasterGlobalCodeTypeRepository(context));
            _lazyIMasterGlobalCodeRepository = new Lazy<IMasterGlobalCodeRepository>(()=>  new MasterGlobalCodeRepository(context));
            _lazyCommonApiRepository = new Lazy<ICommonApiRepository>(() => new CommonApiRepository(context));
            _auditRepo = new Lazy<IAuditRepository>(() => new AuditRepository(context));
            _findingRepo = new Lazy<IFindingRepository>(() => new FindingRepository(_context));
        }

        public IAuditTypeRepository AuditType => _auditTypeRepo.Value;
        public IAuditorRepository Auditor => _auditorRepo.Value;
        public IMasterGlobalCodeTypeRepository MasterGlobalCodeTypeRepository => _lazyIMasterGlobalCodeTypeRepository.Value;
        public IMasterGlobalCodeRepository MasterGlobalCodeRepository => _lazyIMasterGlobalCodeRepository.Value;

        public IMasterGlobalCodeRepository MasterGlobalCode => _lazyIMasterGlobalCodeRepository.Value;

        public IMasterGlobalCodeTypeRepository MasterGlobalCodeType => _lazyIMasterGlobalCodeTypeRepository.Value;
        public ICommonApiRepository CommonApiRepository => _lazyCommonApiRepository.Value;

        public IAuditRepository Audit => _auditRepo.Value;
        public async Task SaveAsync() => await _context.SaveChangesAsync();
        public IFindingRepository Finding => _findingRepo.Value;
    }

}

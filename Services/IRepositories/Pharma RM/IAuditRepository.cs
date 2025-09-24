using Domain.Entities.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositories.Pharma_RM
{
    public interface IAuditRepository
    {
        Task<IEnumerable<Audit>> GetAllAsync();
        Task<Audit?> GetByIdAsync(Guid id);
        Task CreateAsync(Audit audit);
        void Update(Audit audit);
        void Delete(Audit audit);
    }
}

using Domain.Entities.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositories.Pharma_RM
{
    public interface IAuditTypeRepository
    {
        Task<IEnumerable<AuditTypeMaster>> GetAllAsync();
        Task<AuditTypeMaster?> GetByIdAsync(int id);
        Task CreateAsync(AuditTypeMaster entity);
        void Update(AuditTypeMaster entity);
        void Delete(AuditTypeMaster entity);
    }

}

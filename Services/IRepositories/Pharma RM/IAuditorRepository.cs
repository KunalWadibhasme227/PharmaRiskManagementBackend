using Domain.Entities.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositories.Pharma_RM
{
    public interface IAuditorRepository
    {
        Task<IEnumerable<Auditor>> GetAllAsync();
        Task<Auditor?> GetByIdAsync(int id);
        Task CreateAsync(Auditor entity);
        void Update(Auditor entity);
        void Delete(Auditor entity);
    }
}

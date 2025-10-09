using Domain.Entities.Pharma_RM.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositories.Pharma_RM
{
    public interface IHandlingProcedureRepository
    {
        Task<IEnumerable<HandlingProcedure>> GetAllAsync();
        Task<HandlingProcedure?> GetByIdAsync(Guid id);
        Task AddAsync(HandlingProcedure handlingProcedure);
        void Update(HandlingProcedure handlingProcedure);
    }
}

using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositories.Pharma_RM
{
    public interface IMasterGlobalCodeRepository : IRepository<MasterGlobalCode>
    {
        Task<string?> GetNameByIdAsync(int id);
        Task<List<SimpleMasterDto>> GetGlobalCodesByTypeAsync(string typeKey);
    }
}

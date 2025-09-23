using Domain.Entities.Shared;
using Services.IRepositories.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Pharma_RM
{
    public class MasterGlobalCodeTypeRepository(ApplicationDbContext context)
        : Repository<MasterGlobalCodeType>(context), IMasterGlobalCodeTypeRepository
    { }
}

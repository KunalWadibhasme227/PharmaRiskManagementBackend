using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Shared
{
    public interface ICommonService
    {
        Task<List<States>> GetAllStateAsync();
    }
}

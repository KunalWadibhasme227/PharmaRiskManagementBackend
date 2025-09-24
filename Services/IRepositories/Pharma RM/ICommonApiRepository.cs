using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositories.Pharma_RM
{
    public interface ICommonApiRepository
    {
        public Task<List<States>> GetAllStates();
        public Task<List<Cities>> GetCities(int Id);
    }
}

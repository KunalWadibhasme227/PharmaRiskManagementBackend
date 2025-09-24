using Domain.Entities.Shared;
using Services.IRepositories;
using Services.IServices.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Pharma_RM
{
    public class CommonService : ICommonService
    {
        private readonly IRepositoryManager _repositoryManager;
        public CommonService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Task<List<States>> GetAllStateAsync()
        {
            var states = _repositoryManager.CommonApiRepository.GetAllStates();
            return states;
        }
    }
}

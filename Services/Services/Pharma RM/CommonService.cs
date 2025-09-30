using Domain.Entities.Shared;
using Microsoft.Extensions.Logging;
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
        //private readonly ILogger<CommonService> _logger;
        public CommonService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            //_logger = logger;
        }

        public Task<List<States>> GetAllStateAsync()
        {
            try {
                var states = _repositoryManager.CommonApiRepository.GetAllStates();
                return states;
            }
            catch(Exception e)
            {
                //_logger.LogError(e, "Error while fetching all states.");
                throw;
            }

        }

        public Task<List<Cities>> GetAllCitiesAsync(int Id)
        {
            try {
                var cities = _repositoryManager.CommonApiRepository.GetCities(Id);
                return cities;
            }
            catch(Exception e)
            {
                //_logger.LogError(e, "Error While fetching All Cities");
                throw;
            }
        }
    }
}

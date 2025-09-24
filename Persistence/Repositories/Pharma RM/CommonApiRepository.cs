using Domain.Entities.Pharma_RM;
using Domain.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using Services.IRepositories.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Pharma_RM
{
    public class CommonApiRepository : ICommonApiRepository
    {
        private readonly ApplicationDbContext _context;
        public CommonApiRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<States>> GetAllStates()
            => await _context.States.ToListAsync();

        public async Task<List<Cities>> GetCities(int Id)
            => await _context.Cities.Where(x =>x.StateId == Id).ToListAsync();
    }
}

using Common.Models.Dtos.Pharma_RM;
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
    public class MasterGlobalCodeRepository(ApplicationDbContext context) : Repository<MasterGlobalCode>(context),
                                                                            IMasterGlobalCodeRepository 
    {
        public async Task<string?> GetNameByIdAsync(int id)
        {
            var entity = await _context.MasterGlobalCode
                .Where(x => x.Id == id && x.IsActive && !x.IsDeleted)
                .Select(x => x.GlobalCodesName)
                .FirstOrDefaultAsync();

            return entity;
        }

        public async Task<List<SimpleMasterDto>> GetGlobalCodesByTypeAsync(string typeKey)
        {
            return await _context.MasterGlobalCode
                .Where(code => code.IsActive && !code.IsDeleted &&
                               code.MasterGlobalCodeType.GlobalCodesKey == typeKey)
                .OrderBy(code => code.GlobalCodesDisplayOrder)
                .Select(code => new SimpleMasterDto
                {
                    Id = code.Id,
                    Name = code.GlobalCodesName
                })
                .ToListAsync();
        }
    }
}

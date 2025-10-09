using Common.Models.Dtos.Pharma_RM.MaterialFolder;
using Domain.Entities.Pharma_RM.Material;
using Microsoft.EntityFrameworkCore;
using Services.IRepositories.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Pharma_RM
{
    public class HandlingProcedureRepository : IHandlingProcedureRepository
    {
        private readonly ApplicationDbContext _context;


        public HandlingProcedureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HandlingProcedure>> GetAllAsync()
        {
            return await _context.HandlingProcedures.ToListAsync();
        }


        public async Task<HandlingProcedure?> GetByIdAsync(Guid id)
        {
            return await _context.HandlingProcedures.FindAsync(id);
        }

        public async Task AddAsync(HandlingProcedure handlingProcedure)
        {
            await _context.HandlingProcedures.AddAsync(handlingProcedure);
        }

        public void Update(HandlingProcedure handlingProcedure)
        {
            _context.HandlingProcedures.Update(handlingProcedure);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using Common.Models.Dtos.Pharma_RM.FindingFolder;
using Domain.Entities.Pharma_RM;
using Microsoft.EntityFrameworkCore;
using Services.IRepositories.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Pharma_RM
{
    public class FindingRepository : IFindingRepository
    {
        private readonly ApplicationDbContext _context;


        public FindingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Finding>> GetAllAsync(string? filter)
        {
            var query = _context.Findings.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                switch (filter.ToLower())
                {
                    case "open": // Pending + InProgress
                        query = query.Where(f => f.StatusId == 1 || f.StatusId == 2);
                        break;
                    case "closed": // Completed
                        query = query.Where(f => f.StatusId == 3);
                        break;
                    case "overdue":
                        query = query.Where(f => f.DueDate < DateTime.UtcNow && (f.StatusId == 1 || f.StatusId == 2));
                        break;
                    case "all":
                    default:
                        break;
                }
            }

            return await query.ToListAsync();
        }

        public async Task<Finding?> GetByIdAsync(Guid id) =>
            await _context.Findings.FirstOrDefaultAsync(f => f.FindingId == id);

        public async Task<Finding> CreateAsync(Finding entity)
        {
            await _context.Findings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Finding entity)
        {
            _context.Findings.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Finding entity)
        {
            _context.Findings.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<FindingsSummaryDto> GetSummaryCountsAsync()
        {
            var now = DateTime.UtcNow;

            var total = await _context.Findings.CountAsync();
            var open = await _context.Findings.CountAsync(f => f.StatusId == 1 || f.StatusId == 2);
            var overdue = await _context.Findings.CountAsync(f => (f.StatusId == 1 || f.StatusId == 2) && f.DueDate < now);
            var closed = await _context.Findings.CountAsync(f => f.StatusId == 3);

            return new FindingsSummaryDto
            {
                TotalFindings = total,
                OpenFindings = open,
                OverdueFindings = overdue,
                ClosedFindings = closed
            };
        }

    }


}

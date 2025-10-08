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
    public class CategoryRepository : ICategoryRepository 
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryMaster>> GetAllAsync()
            => await _context.CategoryMasters.AsNoTracking().ToListAsync();

        public async Task<CategoryMaster?> GetByIdAsync(int id)
            => await _context.CategoryMasters.FindAsync(id);

        public async Task CreateAsync(CategoryMaster entity)
            => await _context.CategoryMasters.AddAsync(entity);

        public void Update(CategoryMaster entity)
            => _context.CategoryMasters.Update(entity);

        public void Delete(CategoryMaster entity)
            => _context.CategoryMasters.Remove(entity);
    }
}

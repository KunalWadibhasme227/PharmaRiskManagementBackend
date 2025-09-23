using Domain.Entities.Pharma_RM;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Auditor> Auditors { get; set; }
        public DbSet<AuditTypeMaster> AuditTypeMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Global Question Bank



            // DbSet properties for your entities
        }
    }
}

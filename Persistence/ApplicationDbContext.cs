using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using Domain.Entities.Shared;
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
        public DbSet<MasterGlobalCode> MasterGlobalCode { get; set; }
        public DbSet<MasterGlobalCodeType> MasterGlobalCodeType { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Finding> Findings { get; set; }
        public DbSet<Document> Documents { get; set; } = null!;
        public DbSet<MasterGlobalDocuments> MasterGlobalDocuments { get; set; } = null!;
        public DbSet<DocumentWorkflow> DocumentWorkflows { get; set; } = null!;
        public DbSet<DocumentActionLog> DocumentActionLogs { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example configuration: ensure CodeType/CodeValue are unique indices
            modelBuilder.Entity<MasterGlobalDocuments>()
                .HasIndex(c => new { c.DocumentsType, c.DocumentsValue })
                .IsUnique();
        }

        // Implementation of BaseEntity audit fields (CreatedAt, ModifiedAt, etc.) would go here.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Logic to update ModifiedDate, LastUpdated, etc., before saving changes.
            return base.SaveChangesAsync(cancellationToken);
        }
    
      
    }
}

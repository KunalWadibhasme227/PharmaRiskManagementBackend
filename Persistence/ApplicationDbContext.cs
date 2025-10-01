﻿using Common.Models.Dtos.Pharma_RM;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Global Question Bank
        }
    }
}

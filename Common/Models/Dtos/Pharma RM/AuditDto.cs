using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM
{
    public class AuditDto
    {
        public Guid AuditId { get; set; }
        public int SupplierId { get; set; }
        public int AuditType { get; set; }
        public DateTime AuditDate { get; set; }
        public int? LeadAuditor { get; set; }
        public decimal? Score { get; set; }
        public int? StatusId { get; set; }
        public string? Comment { get; set; }

    }

    public class AuditCreateDto
    {
        public int SupplierId { get; set; }
        public int AuditType { get; set; }
        public DateTime AuditDate { get; set; }
        public int? LeadAuditor { get; set; }
        public decimal? Score { get; set; }
        public int? StatusId { get; set; }
        public string? Comment { get; set; }
    }

    public class AuditUpdateDto
    {
        public Guid AuditId { get; set; }
        public int SupplierId { get; set; }
        public int AuditType { get; set; }
        public DateTime AuditDate { get; set; }
        public int? LeadAuditor { get; set; }
        public decimal? Score { get; set; }
        public int? StatusId { get; set; }
        public string? Comment { get; set; }
    }
}

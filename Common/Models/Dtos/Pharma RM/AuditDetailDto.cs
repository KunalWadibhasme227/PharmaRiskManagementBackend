using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM
{
    public class AuditDetailDto
    {
    public Guid AuditId { get; set; }
    public int SupplierId { get; set; }
    public string AuditorName { get; set; } = string.Empty;
    public string AuditTypeName { get; set; } = string.Empty;
    public decimal? Score { get; set; }
    public int StatusId { get; set; }
    public DateTime AuditDate { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int TotalCount { get; set; }  // 👈 new

    }

    // Optional DTO to include pagination info
    public class PagedAuditDetailDto
    {
        public AuditDetailDto[] Records { get; set; } = Array.Empty<AuditDetailDto>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class AuditRequestDto
    {
        public int StatusId { get; set; } = 1; // Default to Active
        public string? SearchText { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

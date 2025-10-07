using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM.FindingFolder
{
    public class FindingForCreateDto
    {
        public Guid AuditId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? TagId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DueDate { get; set; }
        public int? AssigneeId { get; set; }
        public int? ProgressPercent { get; set; }
    }

    public class FindingForUpdateDto : FindingForCreateDto
    {
        public Guid FindingId { get; set; }   // ✅ GUID
    }
}

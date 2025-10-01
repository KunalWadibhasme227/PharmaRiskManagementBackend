using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pharma_RM
{
    [Table("Finding")]
    public class Finding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FindingId { get; set; }

        [Required]
        public Guid AuditId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        public int? TagId { get; set; }

        public int? StatusId { get; set; }   // 1 = Pending, 2 = InProgress, 3 = Completed

        public DateTime? DueDate { get; set; }

        public int? AssigneeId { get; set; }

        public int? ProgressPercent { get; set; }
    }
}

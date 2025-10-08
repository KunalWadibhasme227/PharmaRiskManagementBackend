using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pharma_RM
{
    [Table("Document")]
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }

        [Required, MaxLength(250)]
        public string DocumentTitle { get; set; } = string.Empty;

        [ForeignKey(nameof(Category))]
        public int CategoryDocumentsId { get; set; }
        public MasterGlobalCode? Category { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey(nameof(Status))]
        public int? StatusCodeId { get; set; }
        public MasterGlobalCode? Status { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? ComplianceScore { get; set; }
        public DateTime? LastUpdated { get; set; }

        [MaxLength(50)]
        public string? VersionNumber { get; set; }

        [MaxLength(500)]
        public string? FilePath { get; set; } 

        public DateTime? ReviewDueDate { get; set; }

        [Required]
        public bool IsLatestVersion { get; set; } = true;

        public ICollection<DocumentWorkflow> Workflows { get; set; } = new List<DocumentWorkflow>();
    }
}

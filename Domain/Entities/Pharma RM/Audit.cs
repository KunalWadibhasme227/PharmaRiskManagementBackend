using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pharma_RM
{
    [Table("Audit")]
    public class Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AuditId")]
        public Guid AuditId { get; set; }

        [Required]
        [Column("SupplierId")]
        public int SupplierId { get; set; }

        // Nullable
        [Column("AuditType")]
        public int AuditType { get; set; }

        [Required]
        [Column("AuditDate")]
        public DateTime AuditDate { get; set; }

        // Nullable
        [Column("LeadAuditor")]
        [MaxLength(200)]
        public int? LeadAuditor { get; set; }

        [Column("Score", TypeName = "decimal(5,2)")]
        public decimal? Score { get; set; }

        [Column("StatusId")]
        public int? StatusId { get; set; }

        // Navigation Properties (optional, if you have Supplier / MasterGlobalCodes tables)
        // public Supplier Supplier { get; set; }
        // public MasterGlobalCode Status { get; set; }
    }
}

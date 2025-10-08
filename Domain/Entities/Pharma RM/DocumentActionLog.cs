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
    [Table("DocumentActionLog")]
    public class DocumentActionLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActionLogId { get; set; }

        // FK to Document (Nullable for bulk/system actions)
        [ForeignKey(nameof(Document))]
        public int? DocumentId { get; set; }
        public Document? Document { get; set; }

        // FK to MasterGlobalCodes (Action Type)
        [ForeignKey(nameof(ActionType))]
        public int ActionTypeCodeId { get; set; }
        public MasterGlobalCode? ActionType { get; set; }

        [Required]
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;

        [MaxLength(200)]
        public string? ActionBy { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Notes { get; set; }
    }
}

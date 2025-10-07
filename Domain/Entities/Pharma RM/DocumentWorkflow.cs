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
    [Table("DocumentWorkflow")]
    public class DocumentWorkflow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkflowId { get; set; }

        [ForeignKey(nameof(Document))]
        public int DocumentId { get; set; }
        public Document? Document { get; set; }

        [ForeignKey(nameof(Stage))]
        public int StageCodeId { get; set; }
        public MasterGlobalCode? Stage { get; set; }

        [MaxLength(200)]
        public string? AssignedTo { get; set; }

        public int DocCount { get; set; } = 1;

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? AvgProcessingTime { get; set; }
    }
}

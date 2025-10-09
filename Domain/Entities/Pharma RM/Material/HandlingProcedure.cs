using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pharma_RM.Material
{
    public class HandlingProcedure : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProcedureId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProcedureName { get; set; }

        public DateTime? LastReviewedDate { get; set; }

        public int? StatusCodeId { get; set; }

        public decimal? ComplianceScore { get; set; }
    }
}

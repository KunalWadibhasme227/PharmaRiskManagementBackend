using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM.MaterialFolder
{
    public class HandlingProcedureDto
    {
        public string ProcedureName { get; set; }
        public DateTime? LastReviewedDate { get; set; }
        public int? StatusCodeId { get; set; }
        public decimal? ComplianceScore { get; set; }
    }
}

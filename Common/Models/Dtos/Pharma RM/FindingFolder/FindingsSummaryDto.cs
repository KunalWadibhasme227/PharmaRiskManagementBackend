using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM.FindingFolder
{
    public class FindingsSummaryDto
    {
        public int TotalFindings { get; set; }
        public int OpenFindings { get; set; }     
        public int OverdueFindings { get; set; }  
        public int ClosedFindings { get; set; }    
    }
}

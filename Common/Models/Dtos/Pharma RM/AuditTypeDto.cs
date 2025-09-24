using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM
{
    public class AuditTypeDto
    {
        public int AuditTypeId { get; set; }
        public string TypeName { get; set; }
        public string? Description { get; set; }
    }

    public class AuditTypeForCreationDto
    {
      
        public string TypeName { get; set; }

        public string? Description { get; set; }
    }

    public class AuditTypeForUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }

}

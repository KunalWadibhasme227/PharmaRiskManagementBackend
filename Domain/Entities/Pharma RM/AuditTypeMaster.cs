using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pharma_RM
{
    [Table("AuditTypeMaster")]
    public class AuditTypeMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AuditTypeId")]
        public int AuditTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("TypeName")]
        public string TypeName { get; set; }

        [MaxLength(250)]
        [Column("Description")]
        public string? Description { get; set; }
    }
}

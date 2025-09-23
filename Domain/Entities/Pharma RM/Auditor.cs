using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pharma_RM
{
    [Table("Auditor")]
    public class Auditor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AuditorId")]
        public int AuditorId { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("Name")]
        public string Name { get; set; }

        [MaxLength(200)]
        [Column("Email")]
        public string Email { get; set; }

        [MaxLength(15)]
        [Column("Phone")]
        public string? Phone { get; set; }

    }
}

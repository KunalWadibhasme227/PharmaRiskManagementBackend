using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Shared
{
    public class States
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("STATE_CODE", TypeName = "char(2)")]
        [MaxLength(2)]
        public string StateCode { get; set; } = string.Empty;

        [Required]
        [Column("STATE_NAME", TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string StateName { get; set; } = string.Empty;
    }
}

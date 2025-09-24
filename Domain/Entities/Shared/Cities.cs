using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Shared
{
    public class Cities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(State))]
        [Column("ID_STATE")]
        public int StateId { get; set; }

        [Required]
        [Column("CITY", TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [Required]
        [Column("COUNTY", TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string County { get; set; } = string.Empty;

        [Required]
        [Column("LATITUDE")]
        public double Latitude { get; set; }

        [Required]
        [Column("LONGITUDE")]
        public double Longitude { get; set; }

        // Navigation property (1 State → Many Cities)
        public virtual States State { get; set; } = null!;
    }
}

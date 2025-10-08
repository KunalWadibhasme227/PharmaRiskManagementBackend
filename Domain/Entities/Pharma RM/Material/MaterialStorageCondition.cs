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
    public class MaterialStorageCondition : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StorageConditionId { get; set; }

        [ForeignKey("Material")]
        public Guid MaterialId { get; set; }

        [MaxLength(50)]
        public string? RequiredTemp { get; set; }

        [MaxLength(50)]
        public string? RequiredHumidity { get; set; }

        public decimal? CurrentTemp { get; set; }

        public decimal? CurrentHumidity { get; set; }

        public int? StatusCodeId { get; set; }

        public DateTime? LastChecked { get; set; }

        // Navigation property
        public virtual Materials Material { get; set; }
    }
}

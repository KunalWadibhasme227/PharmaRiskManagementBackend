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
    public class Materials : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MaterialId { get; set; }

        [Required]
        [MaxLength(200)]
        public string MaterialName { get; set; }

        public int? CategoryCodeId { get; set; }

        public int? SupplierId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BatchNumber { get; set; }

        public int? StatusCodeId { get; set; }
        public DateTime? ManufacturingDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        // Navigation properties
        public virtual ICollection<MaterialStorageCondition> StorageConditions { get; set; }
    }
}

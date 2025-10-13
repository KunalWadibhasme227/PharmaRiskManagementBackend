using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM.MaterialFolder
{
    public class AddMaterialDto
    {
        public Guid MaterialId { get; set; }

        [Required]
        [MaxLength(200)]
        public string MaterialName { get; set; }

        public int CategoryCodeId { get; set; }

        public int SupplierId { get; set; }

        [MaxLength(100)]
        public string? BatchNumber { get; set; }

        public int? StatusCodeId { get; set; }

        public DateTime ExpiryDate { get; set; }

        [Required]
        public DateTime? ManufacturingDate { get; set; }
        [MaxLength(50)]
        public string? RequiredTemp { get; set; }

        [MaxLength(50)]
        public string? RequiredHumidity { get; set; }

    }
}

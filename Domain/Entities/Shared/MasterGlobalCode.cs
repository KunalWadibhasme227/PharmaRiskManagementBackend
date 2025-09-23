using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Shared
{
    public class MasterGlobalCode : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid MasterGlobalCodeGuid { get; set; } = Guid.NewGuid();

        [Required]
        public int MasterGlobalCodeTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public required string GlobalCodesKey { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public required string GlobalCodesName { get; set; } = string.Empty;

        public int? GlobalCodesValue { get; set; }

        public int? GlobalCodesDisplayOrder { get; set; }

        [ForeignKey(nameof(MasterGlobalCodeTypeId))]
        public MasterGlobalCodeType MasterGlobalCodeType { get; set; } = null!;
    }
}

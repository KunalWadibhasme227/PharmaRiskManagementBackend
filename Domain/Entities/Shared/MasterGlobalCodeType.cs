using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Shared
{
    public class MasterGlobalCodeType : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid MasterGlobalCodeTypeGuid { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public required string GlobalCodesKey { get; set; }

        [Required]
        [MaxLength(100)]
        public required string GlobalCodesName { get; set; }

        // Navigation property
        public ICollection<MasterGlobalCode> MasterGlobalCodes { get; set; } = new List<MasterGlobalCode>();
    }
}

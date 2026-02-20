using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pharma_RM
{
    [Table("MasterGlobalDocuments")]
    public class MasterGlobalDocuments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GlobalDocumentsId { get; set; }

        [Required, MaxLength(50)]
        public string DocumentsType { get; set; } = string.Empty; 

        [Required, MaxLength(100)]
        public string DocumentsName { get; set; } = string.Empty; 

        [Required, MaxLength(50)]
        public string DocumentsValue { get; set; } = string.Empty; 

        public bool IsActive { get; set; } = true;
    }
}

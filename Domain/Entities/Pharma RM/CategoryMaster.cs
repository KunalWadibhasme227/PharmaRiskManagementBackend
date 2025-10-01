using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pharma_RM
{
    [Table("CategoryMaster")]
    public class CategoryMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CategoryId")]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("CategoryName")]
        public string? CategoryName { get; set; }

    }

}

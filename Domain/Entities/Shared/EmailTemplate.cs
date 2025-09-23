using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shared
{
    public class EmailTemplate : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid EmailTemplateGuid { get; set; } = Guid.NewGuid();

        [MaxLength(200)]
        public string TemplateName { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? TemplateDescription { get; set; }

        [Required]
        [MaxLength(50)]
        public required string TemplateKey { get; set; }

        [Required]
        [MaxLength(500)]
        public string EmailSubject { get; set; } = string.Empty;

        [Required]
        public string Body { get; set; } = string.Empty;

    }
}

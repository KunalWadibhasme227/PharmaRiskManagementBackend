using Domain.Entities.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pharma_RM
{
    [Table("UploadDocuments")]
    public class UploadDocument
    {
        [Key]
        public int DocumentId { get; set; }

        [Required, MaxLength(250)]
        public string DocumentName { get; set; } = null!;

        public int CategoryId { get; set; }

        [MaxLength(250)]
        public string? Audit { get; set; }

        public string? Description { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [MaxLength(20)]
        public string Version { get; set; } = "v1";

        [MaxLength(50)]
        public string Status { get; set; } = "Pending";

        [MaxLength(500)]
        public string? FilePath { get; set; }

        public int? FileSizeKB { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual CategoryMaster Category { get; set; } = null!;
        
    }

    public class UploadDocumentFormModel
    {
        public string? DocumentName { get; set; }
        public int CategoryId { get; set; }
        public string? Audit { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public IFormFile? File { get; set; }

    }

    public class UploadDocumentUpdateFormModel
    {
        public string? DocumentName { get; set; }
        public int CategoryId { get; set; }
        public string? Audit { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public IFormFile? File { get; set; }
    }
}

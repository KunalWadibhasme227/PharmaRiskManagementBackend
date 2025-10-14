using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM
{
    public class UploadDocumentDto
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; } 
        public int AuditId { get; set; } 
        public string? AuditName { get; set; } 
        //public string? Audit { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Version { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? FilePath { get; set; }
        public int? FileSizeKB { get; set; }

        public int TotalCount { get; set; }
    }

    public class PagedUploadDocumentDto
    {
        public UploadDocumentDto[] Records { get; set; } = Array.Empty<UploadDocumentDto>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class UploadDocumentRequestDto
    {
        public string? SearchText { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }

    public class UploadDocumentCreationDto
    {
       
        public string DocumentName { get; set; } = null!;
        public int CategoryId { get; set; }
        public int AuditId { get; set; }
        //public string? Audit { get; set; }
        public string? Description { get; set; }
        public string Version { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? ExpiryDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? FilePath { get; set; }
        public int? FileSizeKB { get; set; }
    }

    public class UploadDocumentUpdateDto
    {
        public string DocumentName { get; set; } = null!;
        public int CategoryId { get; set; }
        public int AuditId { get; set; }
        //public string? Audit { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? FilePath { get; set; }
        public int? FileSizeKB { get; set; }
        public string Version { get; set; } = "v1";
        public string Status { get; set; } = "Pending";
    }

    public class FileDownloadDto
    {
        public byte[] FileContent { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string ContentType { get; set; } = null!;
    }


}

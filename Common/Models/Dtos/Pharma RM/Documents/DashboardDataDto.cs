using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM.Documents
{
    public class DashboardDataDto
    {
        public int TotalDocuments { get; set; }
        public int DocumentsUnderReview { get; set; }
        public int DocumentsOutdated { get; set; }
        public List<DocumentSummaryDto> RecentlyModified { get; set; } = new List<DocumentSummaryDto>();
    }

    public class DocumentSummaryDto
    {
        public int DocumentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class NewDocumentDto
    {
        public string Title { get; set; } = string.Empty;
        public int CategoryDocumentsId { get; set; }
        public string RelativeFilePath { get; set; } = string.Empty;
        public DateTime? ReviewDueDate { get; set; }
    }

    public class WorkflowUpdateDto
    {
        public int NewStageCodeId { get; set; }
        public string? NewAssignedTo { get; set; }
        public string? Notes { get; set; }
    }

    public class FileResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public string RelativeFilePath { get; set; } = string.Empty;
        public string OriginalFileName { get; set; } = string.Empty;
    }
}

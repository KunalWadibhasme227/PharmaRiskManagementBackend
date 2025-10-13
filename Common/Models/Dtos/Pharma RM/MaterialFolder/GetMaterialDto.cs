using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM.MaterialFolder
{
    public class GetMaterialDto
    {
        public Guid MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int CategoryCodeId { get; set; }
        public int SupplierId { get; set; }
        public string? BatchNumber { get; set; }
        public int? StatusCodeId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public string? RequiredTemp { get; set; }
        public string? RequiredHumidity { get; set; }
        public decimal? CurrentTemp { get; set; }
        public decimal? CurrentHumidity { get; set; }
        public int TotalCount { get; set; }

    }

    public class PagedMaterialDetailDto
    {
        public GetMaterialDto[] Records { get; set; } = Array.Empty<GetMaterialDto>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class MaterialRequestDto
    {
        //public int StatusId { get; set; } = 1; // Default to Active
        public string? SearchText { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

using Common.Models.Dtos.Pharma_RM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }

    public class CategoryForCreationDto
    {

        public string? CategoryName { get; set; }

    }

    public class CategoryForUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string? CategoryName { get; set; }

    }

    public class PagedCategoryDetailDto
    {
        public CategoryDto[] Records { get; set; } = Array.Empty<CategoryDto>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class CategoryRequestDto
    {
        public int StatusId { get; set; } = 1; 
        public string? SearchText { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}

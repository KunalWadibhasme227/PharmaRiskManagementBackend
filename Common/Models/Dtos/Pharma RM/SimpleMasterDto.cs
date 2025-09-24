using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM
{
    public class SimpleMasterDto
    {
        public int Id { get; set; }

        // Display label for UI
        public string Name { get; set; } = string.Empty;

        public int? ParentId { get; set; }
    }
}

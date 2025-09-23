using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Dtos.Pharma_RM
{
    public class AuditorDto
    {
        public int AuditorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
    }

    public class AuditorForCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string? Phone { get; set; }
    }

    public class AuditorForUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string? Phone { get; set; }
    }
}

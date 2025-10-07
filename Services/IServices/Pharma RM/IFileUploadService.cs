using Common.Models.Dtos.Pharma_RM.Documents;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Pharma_RM
{
    public interface IFileUploadService
    {
        Task<FileResponseDto> UploadFileAsync(IFormFile file, string documentType);

    }
}

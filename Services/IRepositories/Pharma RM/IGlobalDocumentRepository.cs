using Domain.Entities.Pharma_RM;
using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositories.Pharma_RM
{
    public interface IGlobalDocumentRepository
    {
        Task<MasterGlobalDocuments?> GetCodeByValueAsync(string documentType, string documentValue);
        Task<int?> GetCodeIdByValueAsync(string documentType, string documentValue);
    }
}

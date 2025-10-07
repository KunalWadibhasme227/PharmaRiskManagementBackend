using Common.Models.Dtos.Pharma_RM.FindingFolder;
using Domain.Entities.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepositories.Pharma_RM
{
    public interface IDocumentRepository
    {

        Task<Document?> GetDocumentByIdAsync(int id);
        Task<int> CreateDocumentAsync(Document document);
        Task UpdateDocumentAsync(Document document);
        Task<object> GetDashboardDataFromDbAsync(); 
    }
}

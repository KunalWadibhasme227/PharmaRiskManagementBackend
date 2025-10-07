using Common.Models.Dtos.Pharma_RM;
using Domain.Entities.Pharma_RM;
using Microsoft.EntityFrameworkCore;
using Services.IRepositories.Pharma_RM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace Persistence.Repositories.Pharma_RM
{
    public class AuditRepository : IAuditRepository
    {
        private readonly ApplicationDbContext _context;

        public AuditRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        //public async Task<PagedAuditDetailDto> GetAllAsync(AuditRequestDto auditRequestDto)
        //{
        //    var auditRecords = await _context.AuditDetailDto
        //        .FromSqlInterpolated($@"EXEC dbo.GetAuditDetails 
        //                        @StatusId = {auditRequestDto.StatusId}, 
        //                        @SearchText = {auditRequestDto.SearchText},                                                                                    
        //                        @PageNumber = {auditRequestDto.PageNumber}, 
        //                        @PageSize = {auditRequestDto.PageSize}")
        //        .AsNoTracking()
        //        .ToListAsync();

        //    var totalCount = auditRecords.FirstOrDefault()?.TotalCount ?? 0;

        //    return new PagedAuditDetailDto
        //    {
        //        Records = auditRecords.ToArray(),
        //        PageNumber = auditRequestDto.PageNumber,
        //        PageSize = auditRequestDto.PageSize,
        //        TotalCount = totalCount
        //    };
        //}
        public async Task<PagedAuditDetailDto> GetAllAsync(AuditRequestDto auditRequestDto)
        {
            using var connection = _context.Database.GetDbConnection();

            var auditRecords = await connection.QueryAsync<AuditDetailDto>(
                "dbo.GetAuditDetails",
                new
                {
                    StatusId = auditRequestDto.StatusId,
                    SearchText = auditRequestDto.SearchText,
                    PageNumber = auditRequestDto.PageNumber,
                    PageSize = auditRequestDto.PageSize
                },
                commandType: CommandType.StoredProcedure
            );

            var recordsList = auditRecords.ToList();
            var totalCount = recordsList.FirstOrDefault()?.TotalCount ?? 0;

            return new PagedAuditDetailDto
            {
                Records = recordsList.ToArray(),
                PageNumber = auditRequestDto.PageNumber,
                PageSize = auditRequestDto.PageSize,
                TotalCount = totalCount
            };
        }

        public async Task<Audit?> GetByIdAsync(Guid id)
        {
            return await _context.Audits.FindAsync(id);
        }

        public async Task CreateAsync(Audit audit)
        {
            await _context.Audits.AddAsync(audit);
        }

        public void Update(Audit audit)
        {
            _context.Audits.Update(audit);
        }

        public void Delete(Audit audit)
        {
            _context.Audits.Remove(audit);
        }

       
    }
}

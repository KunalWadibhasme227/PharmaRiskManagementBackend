using Microsoft.EntityFrameworkCore.Storage;

namespace Services.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        public Task<bool> CommitAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

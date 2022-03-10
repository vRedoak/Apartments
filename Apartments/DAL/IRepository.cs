using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Apartments.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {        
        Task InsertAsync(TEntity entity, CancellationToken token);

        Task InsertRangeAsync(TEntity[] entities, CancellationToken token);

        Task<TEntity> FindAsync(object[] keys, CancellationToken token);
        
        void Update(TEntity entity);
        
        void Delete(TEntity entity);

        Task<int> SaveChangesAsync(CancellationToken token);
        
        DbSet<TEntity> Query { get; }

        EntityEntry<TEntity> GetEntityEntry(TEntity entity);
    }
}
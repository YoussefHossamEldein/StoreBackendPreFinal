using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity :BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct = default);
        Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);

    }
}

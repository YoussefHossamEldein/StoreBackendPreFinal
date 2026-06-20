using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity , new()
    {
        private readonly StoreDbContext _dbContext;
        public GenericRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;   
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity; 
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
                return false;
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var existing = await _dbContext.Set<TEntity>().FindAsync(entity.Id);
            if (existing == null)
                return false;
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Set<TEntity>().ToListAsync(ct);
        }

        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id,ct);
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate,ct);

       }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbContext.Set<TEntity>().AnyAsync(predicate, ct);
        }
    }
}

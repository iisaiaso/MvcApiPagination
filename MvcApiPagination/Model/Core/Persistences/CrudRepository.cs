using Microsoft.EntityFrameworkCore;
using MvcApiPagination.Model.Core.Context;
using MvcApiPagination.Model.Core.Repositories;

namespace MvcApiPagination.Model.Core.Persistences
{
    public abstract class CrudRepository<T, ID> : ICrudRepository<T, ID> where T : class
    {
        public readonly ApplicationBbContext _dbContext;
        public CrudRepository(ApplicationBbContext context) 
        {
            _dbContext = context;
        }
        public virtual async Task<T?> DeleteAsync(ID id)
        {
            T? entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity == null) return null;
            else _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IReadOnlyList<T>> FindAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public  virtual async Task<T?> FindByIdAsync(ID id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            EntityState state = _dbContext.Entry(entity).State;
            _ = state switch
            {
                EntityState.Detached => _dbContext.Set<T>().Add(entity),
                EntityState.Modified => _dbContext.Set<T>().Update(entity),
                _ => throw new ArgumentOutOfRangeException()
            };
           await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}

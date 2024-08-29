using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Shared.Database;

public class Repository<T, TId>(DbContext dbContext) : IReposity<T, TId> where T : class, IEntity<TId>
 where TId : struct
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();
    public async ValueTask<TId> Create(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity.Id;
    }

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async ValueTask<T?> Get(TId id) => await _dbSet.FindAsync(id);

    public IQueryable<T> GetAll() => _dbSet.AsQueryable();

    public IQueryable<T> Gets(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);

    public void Update(T entity) => _dbSet.Update(entity);
}

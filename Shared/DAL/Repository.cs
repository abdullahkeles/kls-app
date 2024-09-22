using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Shared.DAL;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T">entity tipi</typeparam>
/// <typeparam name="TId">set edilen entity nin Id tipi</typeparam>
/// <param name="dbContext"></param>
public class Repository<T, TId>(DbContext dbContext) : IRepository<T, TId> where T : class, IEntity<TId>
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();
    public void Add(T entity) => _dbSet.Add(entity);
    public void AddRange(IEnumerable<T> entities) => _dbSet.AddRange(entities);
    public void Update(T entity) => _dbSet.Update(entity);
    public void UpdateRange(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);
    public void Remove(T entity) => _dbSet.Remove(entity);
    public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);

    public IQueryable<T> GetAll() => _dbSet.AsQueryable();
    public IQueryable<T> Filter(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);
    public async ValueTask<T?> GetById(TId id) => await _dbSet.FindAsync(id);
}

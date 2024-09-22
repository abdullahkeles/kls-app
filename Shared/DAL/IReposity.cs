using System;
using System.Linq.Expressions;

namespace Shared.DAL;

public interface IRepository<T, TId> where T : class
{
    IQueryable<T> GetAll();
    IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
    ValueTask<T?> GetById(TId id);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
}

using System;
using System.Linq.Expressions;

namespace Shared.Database;

public interface IReposity<T, TId> where T : class where TId : struct
{
    IQueryable<T> GetAll();
    IQueryable<T> Gets(Expression<Func<T, bool>> predicate);
    ValueTask<T?> Get(TId id);
    void Update(T entity);
    void Delete(T entity);
    ValueTask<TId> Create(T entity);
}

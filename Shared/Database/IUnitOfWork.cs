using System;

namespace Shared.Database;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}

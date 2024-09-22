using System;

namespace Shared.DAL;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}

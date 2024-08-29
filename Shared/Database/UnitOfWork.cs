using System;
using Microsoft.EntityFrameworkCore;

namespace Shared.Database;

public class UnitOfWork(DbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();
}

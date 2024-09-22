using System;
using Microsoft.EntityFrameworkCore;

namespace Shared.DAL;

public class UnitOfWork(DbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();
}

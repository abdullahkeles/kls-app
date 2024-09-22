using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Shared.DAL;
/// <summary>
/// Her Modülümüz için 
/// </summary>
/// <typeparam name="T">Modulede tanımlanan dbcontext</typeparam>
/// <param name="options">DbContextOptions</param>
public abstract class ModuleDbContext<T>(DbContextOptions<T> options) : DbContext(options) where T : DbContext
{
    protected abstract string Schema { get; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!string.IsNullOrWhiteSpace(Schema))
        {
            modelBuilder.HasDefaultSchema(Schema);
        }
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}

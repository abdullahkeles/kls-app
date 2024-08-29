using System;
using Identity.Database.UserEntity;
using Microsoft.EntityFrameworkCore;
using Shared.Database;
namespace Identity.Database;

public class IdentityContext(DbContextOptions<IdentityContext> options) : ModuleDbContext<IdentityContext>(options)
{
    protected override string Schema => "Identity";

    public DbSet<KlsUser> Users { get; set; }
}

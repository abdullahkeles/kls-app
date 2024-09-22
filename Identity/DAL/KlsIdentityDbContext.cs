using System;
using Identity.DAL.Roles;
using Identity.DAL.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.DAL;

public class KlsIdentityDbContext(DbContextOptions<KlsIdentityDbContext> options) : IdentityDbContext<KlsUser, KlsRole, string>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Identity");
        base.OnModelCreating(builder);
    }
}

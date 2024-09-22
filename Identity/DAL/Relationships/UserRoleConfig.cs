using System;
using Identity.DAL.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.DAL.Relationships;

public class UserRoleRelationConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
        .HasMany(x => x.Roles)
        .WithMany(x => x.Users)
        .UsingEntity<UserRole>();
    }
}

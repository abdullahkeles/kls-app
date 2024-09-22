using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.DAL.Roles;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.RoleName).IsRequired();
        builder.HasData(new Role(){
            Id=1,
            RoleGrupId=1,
            RoleName="developer"
        });
    }
}
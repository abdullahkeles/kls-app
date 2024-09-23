using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.DAL.Roles;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.RoleName).IsRequired();
        builder.HasData(new Role()
        {
            Id = "3188a971-25cb-4d5e-b317-81251b78012b",
            RoleGrupId = 1,
            RoleName = "developer"
        });
    }
}
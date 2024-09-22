using System;
using Identity.Helpers.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Helpers.Extensions;

namespace Identity.DAL.Users
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.SurName).IsRequired();
            builder.Property(x => x.Email).IsRequired();

            builder.HasData( new User
            {
                Id = "b77b129b-884f-49b4-bb5b-6237fe702246",
                UserName = "jd",
                Email = "john.doe@example.com",
                MobilePhone = "+1234567890",
                OfficePhone = "+0987654321",
                Password = SecurityHelper.HashCreate("1","aba4e06a-12e0-436f-ae24-655512e13116"),
                Name = "John",
                SurName = "Doe",
                ProfileImageUrl = "https://example.com/profiles/john.jpg",
                UserNameConfirmed = true,
                UserState = UserState.Working,
                RefresToken = "some-random-token",
                RefreshTokenExpire = DateTime.Now.AddDays(7),
                ProfileUrl = "https://example.com/john",
                SecurityKeyExpiryDate = DateTime.Now.AddMonths(1),
                SecurityKey = Guid.NewGuid(),
                Unit = "IT Department",
            },
            new User
            {
                Id = "6f01392c-45b1-4dbf-9457-74a107fe6ada",
                UserName = "js",
                Email = "jane.smith@example.com",
                MobilePhone = "+1987654321",
                OfficePhone = "+1123456789",
                Password = SecurityHelper.HashCreate("1","aba4e06a-12e0-436f-ae24-655512e13116"),
                Name = "Jane",
                SurName = "Smith",
                ProfileImageUrl = "https://example.com/profiles/jane.jpg",
                UserNameConfirmed = false,
                UserState = UserState.Working,
                RefresToken = "another-random-token",
                RefreshTokenExpire = DateTime.Now.AddDays(5),
                ProfileUrl = "https://example.com/jane",
                SecurityKeyExpiryDate = DateTime.Now.AddMonths(2),
                SecurityKey = Guid.NewGuid(),
                Unit = "HR Department"
            });

           
        }
    }
}

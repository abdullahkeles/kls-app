using System;

namespace Identity.DAL.Users.Models;


public class RefreshTokenUserDto
{
    public required string UserId { get; set; }
    public DateTimeOffset? RefreshTokenExpire { get; set; }
    public string[] Roles { get; set; } = [];
    public required string UserName { get; set; }
    public bool IsValid() => RefreshTokenExpire > DateTimeOffset.UtcNow;
}

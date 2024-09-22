using System;

namespace Identity.DAL.Users.Models;


public class RefreshTokenUserDto
{
    public required string UserId { get; set; }
    public DateTimeOffset? TokenExpireDate { get; set; }
    public string[] Roles { get; set; } = [];
    public required string UserName { get; set; }
}

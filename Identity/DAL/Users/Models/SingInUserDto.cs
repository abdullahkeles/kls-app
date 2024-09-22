using System;

namespace Identity.DAL.Users.Models;

public class SingInUserDto
{
    public required string Id { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string SurName { get; set; }
    public required string RefresToken { get; set; }
    public DateTimeOffset? RefreshTokenExpire { get; set; }
    public IEnumerable<string> Roles { get; set; } = [];
}

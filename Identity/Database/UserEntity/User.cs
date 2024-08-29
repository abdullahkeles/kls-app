using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Database;

namespace Identity.Database.UserEntity;

public class KlsUser : IEntity<string>
{
    public string Id { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? MobilePhone { get; set; }
    public string? OfficePhone { get; set; }
    public string Password { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string SurName { get; set; } = default!;
    public string? ProfileImageUrl { get; set; }
    public bool? UserNameConfirmed { get; set; }
    public int? UserState { get; set; }
    public string? Token { get; set; }
    public DateTimeOffset? TokenExpireDate { get; set; }
    public string? ProfileUrl { get; set; }
    public DateTimeOffset? SecurityKeyExpiryDate { get; set; }
    public Guid? SecurityKey { get; set; }

}

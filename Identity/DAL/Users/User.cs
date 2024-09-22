using Identity.DAL.Roles;
using Identity.Helpers.Constants;
using Shared.DAL;

namespace Identity.DAL.Users;
#nullable disable
public class User : IEntity<string>
{
    public User()
    {
        Id = Guid.NewGuid().ToString();
        Roles = [];
    }
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string MobilePhone { get; set; }
    public string OfficePhone { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string ProfileImageUrl { get; set; }
    public bool UserNameConfirmed { get; set; }
    public UserState UserState { get; set; }
    public string RefresToken { get; set; }
    public DateTimeOffset? RefreshTokenExpire { get; set; }
    public string ProfileUrl { get; set; }
    public DateTimeOffset? SecurityKeyExpiryDate { get; set; }
    public Guid? SecurityKey { get; set; }
    public string Unit { get; set; }
    public List<Role> Roles { get; }
}

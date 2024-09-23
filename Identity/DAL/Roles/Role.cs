using System;
using Identity.DAL.Users;
using Shared.DAL;

namespace Identity.DAL.Roles;

#nullable disable
public class Role : IEntity<string>
{
    public Role()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public int RoleGrupId { get; set; }
    public string RoleName { get; set; }
    public List<User> Users { get; } = [];
}

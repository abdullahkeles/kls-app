using Shared.DAL;

namespace Identity.DAL.Relationships;
#nullable disable
public class UserRole : IEntity<int>
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int RoleId { get; set; }
}

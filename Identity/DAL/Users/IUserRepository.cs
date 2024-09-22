using System;
using Identity.DAL.Users.Models;
using Shared.DAL;

namespace Identity.DAL.Users;

public interface IUserRepository : IRepository<User, string>
{
    ValueTask<SingInUserDto?> GetUserName(string id);
    ValueTask<RefreshTokenUserDto?> GetRefreshToken(string refreshToken);
    Task SetRefreshToken(string refreshToken, DateTimeOffset refreshTokenExpiration, string userName);
}

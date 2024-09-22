using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Identity.DAL;
using Identity.DAL.Users.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DAL;
using SQLitePCL;

namespace Identity.DAL.Users;

public class UserRepository(IdentityDbContext context, IMapper mapper) : Repository<User, string>(context), IUserRepository
{
   public async ValueTask<RefreshTokenUserDto?> GetRefreshToken(string refreshToken) => await context.Users.Where(x => x.RefresToken.Equals(refreshToken)).Select(x => mapper.Map<RefreshTokenUserDto>(x)).SingleOrDefaultAsync();


   public async ValueTask<SingInUserDto?> GetUserName(string userName) =>
      mapper.Map<SingInUserDto>(await context.Users.Include(i => i.Roles).SingleOrDefaultAsync(x => x.UserName == userName));

   public async Task SetRefreshToken(string refreshToken, DateTimeOffset refreshTokenExpiration, string userId)
   {
      var user = await GetById(userId);
      if (user is not null)
      {
         user.RefresToken = refreshToken;
         user.RefreshTokenExpire = refreshTokenExpiration;
      }
   }
}

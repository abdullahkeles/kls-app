using System;
using System.Net;
using Identity.BLL.Auth.Post;
using Identity.BLL.Token;
using Identity.BLL.Token.Models;
using Identity.DAL.Users;
using Identity.Helpers.Constants;
using Identity.Helpers.Constants.JwtSettings;
using Microsoft.Extensions.DependencyInjection;
using Shared.DAL;
using Shared.Helpers.Constants.AppSettings;
using Shared.Helpers.Extensions;
using Shared.Helpers.Services;

namespace Identity.BLL.Auth;

public class AuthService(IUserRepository userRepository, ITokenService tokenService, IKlsAppContext klsAppContext, [FromKeyedServices("uowIdentity")] IUnitOfWork unitOfWork) : IAuthService
{

    public async Task<ServiceResult> SingIn(AuthRequest auth)
    {
        var user = await userRepository.GetUserName(auth.userName);
        if (user is null)
        {
            return ServiceResult.Fail(HttpStatusCode.NotFound, IdentityMessage.Auth.UserNotFoun);
        }
        if (!auth.password.ValidateHash(klsAppContext.Salt, user.Password))
        {
            return ServiceResult.Fail(HttpStatusCode.BadRequest, IdentityMessage.Auth.PasswordUnvalid);
        }
        var token = tokenService.CreateToken(user.UserName, user.Roles.ToArray());
        await userRepository.SetRefreshToken(token.RefreshToken, token.RefreshExpire, user.Id);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult<TokenResponse>.Success(HttpStatusCode.OK, token);
    }

    public async Task<ServiceResult> SingInRefreshToken(RefreshTokenRequest request)
    {
        var token = await userRepository.GetRefreshToken(request.refreshToken.ToString());
        if (token is null)
            return ServiceResult.Fail(HttpStatusCode.NotFound, IdentityMessage.Auth.RefreshTokenNotFoun);
        if (DateTime.UtcNow > token.TokenExpireDate)
            return ServiceResult.Fail(HttpStatusCode.RequestTimeout, IdentityMessage.Auth.TokenExpired);
        var newToken = tokenService.CreateToken(token.UserName, token.Roles);
        await userRepository.SetRefreshToken(newToken.RefreshToken, newToken.RefreshExpire, token.UserId);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult<TokenResponse>.Success(HttpStatusCode.OK, newToken);
    }
}

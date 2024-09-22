using System;
using Identity.BLL.Auth.Post;
using Shared.Helpers.Services;

namespace Identity.BLL.Auth;

public interface IAuthService
{
        Task<ServiceResult> SingIn(AuthRequest auth);
        Task<ServiceResult> SingInRefreshToken(RefreshTokenRequest request);
}

using Identity.BLL.Auth.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.BLL.Controllers;
using Shared.Helpers.Services;

namespace Identity.BLL.Auth
{
    public class AuthController(IAuthService authService) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SingIn([FromBody] AuthRequest request) => ApiResponse(await authService.SingIn(request));
        // [HttpPost]
        // public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest,int id) => ApiResponse(await authService.SingInRefreshToken(refreshTokenRequest));
    }
}

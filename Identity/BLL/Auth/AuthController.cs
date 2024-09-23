using Identity.BLL.Auth.Post;
using Identity.DAL.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.BLL.Controllers;
using Shared.Helpers.Services;

namespace Identity.BLL.Auth
{
    public class AuthController(IAuthService authService) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SingIn([FromBody] AuthRequest request) => ApiResponse(await authService.SingIn(request));
    }
}

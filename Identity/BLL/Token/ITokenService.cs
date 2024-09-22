using System;
using Identity.BLL.Token.Models;
using Shared.Helpers.Services;

namespace Identity.BLL.Token;

public interface ITokenService
{
    TokenResponse CreateToken(string username, string[] roles);
    ResolveToken ResolveToken(string token);
}

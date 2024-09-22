using System;

namespace Identity.BLL.Token.Models;

public class TokenResponse
{
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
    public DateTimeOffset TokenExpire { get; set; }
    public DateTimeOffset RefreshExpire { get; set; }
}

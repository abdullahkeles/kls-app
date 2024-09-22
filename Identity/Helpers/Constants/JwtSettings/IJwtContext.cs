using System;

namespace Identity.Helpers.Constants.JwtSettings;

public interface IJwtContext
{
    string Scheme { get; set; }
    string Secret { get; set; }
    int ExpToken { get; set; }
    int ExpRefreshToken { get; set; }
    string ValidIssuer { get; set; }
    string ValidAudience { get; set; }
}
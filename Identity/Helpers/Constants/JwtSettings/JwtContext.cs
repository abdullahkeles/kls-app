using System;
using Microsoft.Extensions.Configuration;

namespace Identity.Helpers.Constants.JwtSettings;



public class JwtContext : IJwtContext
{
    public string Scheme { get; set; }
    public string Secret { get; set; }
    public int ExpToken { get; set; }
    public int ExpRefreshToken { get; set; }
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }

    public JwtContext(IConfiguration configuration)
    {
        var jwtSection = configuration.GetSection("JWT");

        Scheme = jwtSection["Scheme"] ?? "";
        Secret = jwtSection["Secret"] ?? "";
        ExpToken = int.Parse(jwtSection["ExpToken"] ?? "-1");
        ExpRefreshToken = int.Parse(jwtSection["ExpRefreshToken"] ?? "-1");
        ValidIssuer = jwtSection["ValidIssuer"] ?? "";
        ValidAudience = jwtSection["ValidAudience"] ?? "";
    }
}

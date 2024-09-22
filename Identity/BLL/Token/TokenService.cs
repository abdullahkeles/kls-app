using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Identity.BLL.Token.Models;
using Identity.Helpers.Constants;
using Identity.Helpers.Constants.JwtSettings;
using Microsoft.IdentityModel.Tokens;

namespace Identity.BLL.Token;

internal class TokenService(IJwtContext jwtContext) : ITokenService
{

    public TokenResponse CreateToken(string username, string[] roles)
    {
        // Token imzalama için gerekli güvenlik anahtarı
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtContext.Secret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Kullanıcı bilgileri (claims) ve rollerin eklenmesi
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, username), // Kullanıcı adı
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Token'a benzersiz bir ID ekler
        };

        // Her bir rolü claims'e ekle
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        var expDate = DateTime.UtcNow.AddMinutes(jwtContext.ExpToken);
        // Token oluşturma ayarları
        var token = new JwtSecurityToken(
            issuer: jwtContext.ValidIssuer, // Token'ı oluşturan (genelde API veya uygulama adı)
            audience: jwtContext.ValidAudience, // Token'ı alacak hedef kitle
            claims: claims, // Kullanıcı bilgileri
            expires: DateTime.UtcNow.AddMinutes(jwtContext.ExpToken), // Token'ın geçerlilik süresi
            signingCredentials: credentials // Token imzası
        );

        // Token'ı ve son kullanma zamanı ile geri dönüyoruz.
        return new TokenResponse() { Token = new JwtSecurityTokenHandler().WriteToken(token), TokenExpire = expDate, RefreshExpire = DateTime.UtcNow.AddMinutes(jwtContext.ExpRefreshToken), RefreshToken = Guid.NewGuid().ToString() };
    }
    public ResolveToken ResolveToken(string token)
    {
        var resolveToken = new ResolveToken();

        try
        {
            // Token doğrulama parametreleri
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtContext.ValidIssuer,
                ValidAudience = jwtContext.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtContext.Secret)),
                ClockSkew = TimeSpan.Zero // Zaman farkını ortadan kaldırır
            };

            // Token çözümleyici
            var tokenHandler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

            // Token geçerli ise
            if (validatedToken is JwtSecurityToken jwtToken)
            {
                resolveToken.IsValid = true;
                resolveToken.Claims = principal.Claims;
                resolveToken.ExpiryDate = jwtToken.ValidTo;
            }
        }
        catch (SecurityTokenExpiredException ex)
        {
            // Token süresi dolmuşsa
            resolveToken.IsValid = false;
            resolveToken.ErrorMessage = IdentityMessage.Auth.TokenExpired;
            resolveToken.ExpiryDate = ex.Expires;
        }
        catch (Exception ex)
        {
            // Diğer hatalar
            resolveToken.IsValid = false;
            resolveToken.ErrorMessage = IdentityMessage.Auth.TokenException(ex.Message);
        }

        return resolveToken;
    }
}

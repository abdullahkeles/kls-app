using System;
using System.Text;
using Identity.DAL.Users;
using Identity.Helpers.Constants.JwtSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Helpers.Extensions;

public static class AuthenticationExtension
{
    public static IServiceCollection AddAuthenticationJwt(this IServiceCollection services, IJwtContext jwtContext)
    {
        services.AddAuthentication(jwtContext.Scheme).AddJwtBearer(jwtContext.Scheme, options =>
        {
            services.BuildServiceProvider().GetRequiredService<IJwtContext>();
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = jwtContext.ValidIssuer,
                ValidAudience = jwtContext.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtContext.Secret)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };

        });
        services.Configure<IdentityOptions>(options =>
{
    // Default SignIn settings.
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});
        return services;
    }

}


// Açıklamalar

// 	1.	ValidIssuer
// 	•	Açıklama: Bu, token’ı üreten geçerli (valid) issuer’ı (yayımcı) belirtir. Issuer, token’ı hangi uygulamanın verdiğini tanımlamak için kullanılır.
// 	•	Zorunlu mu? Evet, eğer ValidateIssuer = true ise, ValidIssuer değeri zorunludur. Bu ayar, token’ın belirli bir issuer tarafından oluşturulup oluşturulmadığını kontrol eder.
// 	2.	ValidAudience
// 	•	Açıklama: Bu ayar, token’ın hangi hedef kitleye (audience) yönelik olduğunu belirtir. Audience, token’ın hangi servis veya kullanıcı grubu için geçerli olduğunu tanımlar.
// 	•	Zorunlu mu? Evet, ValidateAudience = true ise, ValidAudience değeri zorunludur. Token, belirtilen hedef kitlenin doğruluğu kontrol edilerek doğrulanır.
// 	3.	IssuerSigningKey
// 	•	Açıklama: Bu ayar, token’ın imzasını doğrulamak için kullanılan simetrik anahtardır (secret key). Token’ın imzası, bu anahtarla üretilir ve doğrulama sırasında token’ın değiştirilip değiştirilmediği kontrol edilir.
// 	•	Zorunlu mu? Evet, JWT imzasının doğrulanması için IssuerSigningKey zorunludur. Bu anahtar olmadan imzalama ve doğrulama işlemi yapılamaz.
// 	4.	ValidateIssuer
// 	•	Açıklama: Bu ayar, token’ın issuer (yayımcı) bilgisinin doğrulanıp doğrulanmayacağını belirler. Eğer true ise, token’ı belirttiğiniz ValidIssuer’a göre kontrol eder.
// 	•	Zorunlu mu? Hayır, isteğe bağlıdır. Ancak güvenlik için genellikle true yapılması tavsiye edilir.
// 	5.	ValidateAudience
// 	•	Açıklama: Token’ın audience (hedef kitle) bilgisinin doğrulanıp doğrulanmayacağını belirler. Eğer true ise, token’ı ValidAudience değerine göre doğrular.
// 	•	Zorunlu mu? Hayır, isteğe bağlıdır. Güvenlik açısından genellikle true yapılması önerilir.
// 	6.	ValidateLifetime
// 	•	Açıklama: Token’ın süresinin dolup dolmadığını kontrol eder. Eğer true ise, token’ın geçerlilik süresi dolmuşsa token geçersiz sayılır.
// 	•	Zorunlu mu? Hayır, isteğe bağlıdır. Fakat güvenlik açısından true yapılması tavsiye edilir. Ancak bu örnekte false olarak ayarlanmış, yani token’ın geçerlilik süresi kontrol edilmeyecek.
// 	7.	ValidateIssuerSigningKey
// 	•	Açıklama: Token’ın imza anahtarının doğrulanıp doğrulanmayacağını belirtir. Eğer true ise, token’ın IssuerSigningKey ile imzalanıp imzalanmadığını doğrular.
// 	•	Zorunlu mu? Evet, güvenlik için genellikle true yapılması önerilir, çünkü bu ayar imzanın doğruluğunu kontrol eder ve token’ın üzerinde oynama olup olmadığını belirler.

// Zorunlu Olanlar:

// 	•	IssuerSigningKey: İmzalama ve doğrulama işlemi için gereklidir.
// 	•	ValidIssuer: Eğer ValidateIssuer = true ise, issuer (yayımcı) doğrulaması yapılacağından bu değerin ayarlanması gerekir.
// 	•	ValidAudience: Eğer ValidateAudience = true ise, audience (hedef kitle) doğrulaması için bu ayarın yapılması gereklidir.
// 	•	ValidateIssuerSigningKey: Güvenlik açısından token imzasının doğruluğunu kontrol etmek için genellikle true yapılır ve bu durumda zorunludur.

// Zorunlu Olmayanlar (İsteğe Bağlı):

// 	•	ValidateIssuer ve ValidateAudience: Bu doğrulamaları devre dışı bırakabilirsiniz, ancak güvenlik için genellikle aktif tutulur.
// 	•	ValidateLifetime: Token’ın geçerlilik süresi kontrol edilsin istemiyorsanız, bu ayarı false yapabilirsiniz.

// Güvenlik açısından genellikle tüm doğrulama işlemlerini aktif hale getirmeniz tavsiye edilir.
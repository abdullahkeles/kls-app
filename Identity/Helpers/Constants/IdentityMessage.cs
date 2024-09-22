using System;

namespace Identity.Helpers.Constants;

public class IdentityMessage
{
    public class Auth
    {
        public static string UserNotFoun => "Kullanıcı bulunamadı.";
        public static string PasswordUnvalid => "Şifre doğru değil.";
        public static string TokenExpired => "Token süresi dolmuş.";
        public static string RefreshTokenNotFoun => "Refresh Token bulunamadı";
        public static string TokenException(string message) => $"Token doğrulama hatası: {message}";
    }

}

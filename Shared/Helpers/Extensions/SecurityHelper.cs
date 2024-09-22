using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Shared.Helpers.Extensions;

public static class SecurityHelper
{
    public static string HashCreate(this string value, string salt)
    {
        var valueBytes = KeyDerivation.Pbkdf2(
            password: value,
            salt: System.Text.Encoding.UTF8.GetBytes(salt),
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10000,
            numBytesRequested: 256 / 8);
        return Convert.ToBase64String(valueBytes);
    }

    /// <summary>
    /// şifreleme doğru ise true döner
    /// </summary>
    /// <param name="value">hash lenmemiş şifre</param>
    /// <param name="salt">şifre karıştırıcı</param>
    /// <param name="hash">tek yönlü şifrelenmiş metin</param>
    /// <returns></returns>
    public static bool ValidateHash(this string value, string salt, string hash)
        => HashCreate(value, salt) == hash;


}

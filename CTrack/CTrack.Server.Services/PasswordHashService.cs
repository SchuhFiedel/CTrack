using CTrack.Server.Contracts.Services;
using System.Security.Cryptography;

namespace CTrack.Server.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        private const int SaltSize = 128 / 8;
        private const int KeySize = 256 / 8;
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName Algname = HashAlgorithmName.SHA256;
        private static char Delim = '.';

        string IPasswordHashService.Hash(string pw)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(pw, salt, Iterations, Algname, KeySize);

            return string.Join(Delim, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        bool IPasswordHashService.Verify(string passwordHash, string inputPassword)
        {
            var elements = passwordHash.Split(Delim);
            var salt = Convert.FromBase64String(elements[0]);
            var hash = Convert.FromBase64String(elements[1]);

            var hashedInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iterations, Algname, KeySize);

            return CryptographicOperations.FixedTimeEquals(hash, hashedInput);
        }
    }
    
}

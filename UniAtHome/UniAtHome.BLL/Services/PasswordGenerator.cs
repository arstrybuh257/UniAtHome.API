using System;
using System.Security.Cryptography;
using System.Text;
using UniAtHome.BLL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public class PasswordGenerator : IPasswordGenerator
    {
        const int alphabeticalCount = 4 * 3;

        const int specialCharsCount = 1;

        const int digitsCount = 2;

        public string GeneratePassword()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                StringBuilder sb = new StringBuilder();

                AppendAlphabeticalSymbols(rng, sb);
                AppendSpecialChatacters(rng, sb);
                AppendDigits(rng, sb);

                return sb.ToString();
            }
        }
        private static void AppendAlphabeticalSymbols(RandomNumberGenerator rng, StringBuilder sb)
        {
            var passwordLetters = new byte[alphabeticalCount];
            rng.GetBytes(passwordLetters);
            string letters = Convert.ToBase64String(passwordLetters);
            sb.Append(letters);
        }

        private static void AppendSpecialChatacters(RandomNumberGenerator rng, StringBuilder sb)
        {
            var nonAlphanumerics = new byte[specialCharsCount];
            var nonAlphanumericsPositions = new byte[specialCharsCount];
            rng.GetBytes(nonAlphanumerics);
            rng.GetBytes(nonAlphanumericsPositions);
            for (int i = 0; i < specialCharsCount; i++)
            {
                sb.Insert(nonAlphanumericsPositions[i] % sb.Length, '#' + (nonAlphanumerics[i] % ('/' - '#')));
            }
        }

        private static void AppendDigits(RandomNumberGenerator rng, StringBuilder sb)
        {
            var digits = new byte[digitsCount];
            var digitsPositions = new byte[digitsCount];
            rng.GetBytes(digits);
            rng.GetBytes(digitsPositions);
            for (int i = 0; i < digitsCount; i++)
            {
                sb.Insert(digitsPositions[i] % sb.Length, '0' + (digits[i] % 10));
            }
        }
    }
}

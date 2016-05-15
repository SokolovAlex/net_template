using System;
using System.Security.Cryptography;
using System.Text;
using App.BLL.Helpers.Interfaces;

namespace App.BLL.Helpers
{

    public sealed class HashHelper : IHashHelper
    {
        #region private

        private static string ConvertByteToString(byte[] data)
        {
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        #endregion

        #region Interfaces

        #region IHashHelper Members

        public string GetMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            var md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            return ConvertByteToString(data);
        }

        public string GetSHA256Hash(string input)
        {
            var hasher = new SHA256Managed();
            var data = hasher.ComputeHash(Encoding.Default.GetBytes(input));

            return ConvertByteToString(data);
        }

        public string GetSHA512Hash(string input)
        {
            var hasher = new SHA512Managed();
            var data = hasher.ComputeHash(Encoding.Default.GetBytes(input));

            return ConvertByteToString(data);
        }

        public string GetHash()
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            characters += alphabets + small_alphabets + numbers;
            int length = 12;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }

        public string GetSalt()
        {
            var bytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(bytes);
            return GetMd5Hash(BitConverter.ToString(bytes).Replace("-", ""));
        }

        public string GetPassword(int length = 4)
        {
            var password = new byte[length];

            using (var rngCsp = new RNGCryptoServiceProvider())
                rngCsp.GetBytes(password);

            var code = BitConverter.ToString(password).Replace("-", "");
            return code;
        }

        public string GetSaltPassword(string password, string salt)
        {
            if (string.IsNullOrEmpty(password)) return password;
            var result = new StringBuilder();

            for (int c = 0; c < password.Length; c++)
                result.Append((char)((uint)password[c] ^ (uint)salt[c]));

            return GetMd5Hash(result.ToString());
        }

        #endregion

        #endregion
    }
}
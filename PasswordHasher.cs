using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;

namespace BookManagement
{
    static public class PasswordHasher
    {
        static public string Hash(string password)
        {
            using (var engine = SHA256.Create()) 
            {
                var raw_password = Encoding.UTF8.GetBytes(password);
                for (int i = 0; i<raw_password.Length; i++)
                    raw_password[i] ^= (byte)((i + 38) % 256);
                var hash_password = engine.ComputeHash(raw_password, 0, raw_password.Length);
                password = BitConverter.ToString(hash_password).Replace("-", "").ToLower();
            }
            
            using (var engine = MD5.Create())
            {
                var raw_password = Encoding.UTF8.GetBytes(password);
                for (int i = 0; i < raw_password.Length; i++)
                    raw_password[i] ^= (byte)((i + 98) % 256);
                var hash_password = engine.ComputeHash(raw_password, 0, raw_password.Length);
                password = BitConverter.ToString(hash_password).Replace("-", "").ToLower();
            }

            return password;
        }
    }
}

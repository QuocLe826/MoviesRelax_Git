using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace MoviesRelax.Security
{
    public static class MD5Security
    {
        public static string Encrypt(string strText)
        {
            try
            {
                var hash = "Password@2022$";
                var data = UTF8Encoding.UTF8.GetBytes(strText);

                var md5 = new MD5CryptoServiceProvider();
                var tripDES = new TripleDESCryptoServiceProvider();

                tripDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                tripDES.Mode = CipherMode.ECB;

                var transform = tripDES.CreateEncryptor();
                var result = transform.TransformFinalBlock(data, 0, data.Length);

                return Convert.ToBase64String(result);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string Decrypt(string text)
        {
            try
            {
                var hash = "Password@2022$";
                var data = Convert.FromBase64String(text);

                var md5 = new MD5CryptoServiceProvider();
                var tripDES = new TripleDESCryptoServiceProvider();

                tripDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                tripDES.Mode = CipherMode.ECB;

                var transform = tripDES.CreateDecryptor();
                var result = transform.TransformFinalBlock(data, 0, data.Length);

                return UTF8Encoding.UTF8.GetString(result);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}

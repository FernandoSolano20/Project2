using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace CoreAPI.AppCode.Helper
{
    public static class CodigoHelper
    {
        private const string _lowers = "abcdefghijklmnopqrstuvwxyz";
        private const string _uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string _number = "0123456789";
        private const string _specialChars = "$%^&*!@#+-";
        public static string GenerarCodigo(int lowercase, int uppercase, int numerics, int special)
        {
            Random random = new Random();

            string generated = "!";
            for (var i = 1; i <= lowercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    _lowers[random.Next(_lowers.Length - 1)].ToString()
                );

            for (var i = 1; i <= uppercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    _uppers[random.Next(_uppers.Length - 1)].ToString()
                );

            for (var i = 1; i <= numerics; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    _number[random.Next(_number.Length - 1)].ToString()
                );

            for (var i = 1; i <= special; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    _specialChars[random.Next(_specialChars.Length - 1)].ToString()
                );

            return generated.Replace("!", string.Empty);
        }

        public static string md5(this string Value)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Value);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }
    }
}

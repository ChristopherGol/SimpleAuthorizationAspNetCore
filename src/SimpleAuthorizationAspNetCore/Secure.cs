using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthorizationAspNetCore
{
    public static class Secure
    {
        public static string MD5Hash(string plainText)
        {
            using (var provider = MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(plainText)))
                    builder.Append(b.ToString("x2").ToLower());

                return builder.ToString();
            }
        }
    }
}

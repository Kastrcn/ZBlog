using System;
using System.Security.Cryptography;
using System.Text;

namespace ZBlog.Utils
{
    public class GravatarUtils
    {
        public static String getGravatar(String email)
        {
            return $"https://secure.gravatar.com/avatar/{MD5Hash(email.ToLower())}";
        }

        /// netcore下的实现MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }
    }
}
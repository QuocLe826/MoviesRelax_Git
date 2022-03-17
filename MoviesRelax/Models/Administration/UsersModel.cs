using MoviesRelax.Models;
using MoviesRelax.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRelax.Models
{
    public class UsersModel
    {
        public string Login(string username, string password)
        {
            using (var context = new MOVIES_RELAX_Entities())
            {
                var user = (from x in context.USERS where x.Username == username select x).SingleOrDefault();
                var pwdDecrypt = MD5Security.Decrypt(user.Password);
                if(password == pwdDecrypt)
                {
                    user.LastLogin = DateTime.Now;
                    context.SaveChanges();
                    return "";
                }
            }
            return "Tên đăng nhập hoặc mật khẩu không chính xác";
        }
    }
}
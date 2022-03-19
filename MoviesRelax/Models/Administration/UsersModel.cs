using MoviesRelax.Models;
using MoviesRelax.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesRelax.Models
{
    public class UsersModel: EntityModel
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

        public List<SelectListItem> GetUserTypes()
        {
            var lstSelect = new List<SelectListItem>();
            using (var context = new MOVIES_RELAX_Entities())
            {
                var data = context.USER_TYPES.ToList();
                foreach (USER_TYPES item in data)
                {
                    lstSelect.Add(new SelectListItem() { Text = item.Name, Value = item.Code });
                }
            }
            return lstSelect;
        }

        public USER GetUser(string code)
        {
            using (var context = new MOVIES_RELAX_Entities())
            {
                return context.USERS.SingleOrDefault(x => x.Code == code);
            }
        }

        public List<USER> GetUsers()
        {
            var data = new List<USER>();
            using (var context = new MOVIES_RELAX_Entities())
            {
                var query = from x in context.USERS
                            select new
                            {
                                x.Code,
                                x.FullName,
                                x.Email,
                                x.Username,
                                x.Password,
                                x.UserType,
                                x.Auth,
                                x.PhotoPath,
                                x.Status,
                                x.LastLogin,
                                x.TimeCreated,
                                TimeUpdated = x.TimeUpdated == null ? x.TimeCreated : x.TimeUpdated
                            };
                foreach (var item in query)
                {
                    data.Add(new USER()
                    {
                        Code = item.Code,
                        FullName = item.FullName,
                        Email = item.Email,
                        Username = item.Username,
                        Password = item.Password,
                        UserType = item.UserType,
                        Auth = item.Auth == "" ? "Chưa phân quyền" : "Xem chi tiết",
                        PhotoPath = item.PhotoPath,
                        Status = item.Status == "O" ? "Đang hoạt động" : "Ngoại tuyến",
                        LastLogin = item.LastLogin,
                        TimeCreated = item.TimeCreated,
                        TimeUpdated = item.TimeUpdated
                    });
                }
            }
            return data;
        }

        public string SaveData(USER model, string type)
        {
            var result = "";
            using (var context = new MOVIES_RELAX_Entities())
            {
                if (type == "A")
                {
                    model.Code = GetNewCode();
                    model.Password = MD5Security.Encrypt(model.Password);
                    model.TimeCreated = DateTime.Now;
                    context.USERS.Add(model);
                }
                else
                {
                    var data = context.USERS.SingleOrDefault(m => m.Code == model.Code);
                    data.FullName = model.FullName;
                    data.Email = model.Email;
                    data.Username = model.Username;
                    data.Password = model.Password;
                    data.UserType = model.UserType;
                    data.Auth = model.Auth;
                    data.PhotoPath = model.PhotoPath;
                    data.TimeUpdated = DateTime.Now;
                }
                if (context.SaveChanges() < 1)
                    result = "Lưu thất bại";
            }
            return result;
        }

        public string DeleteData(string code)
        {
            using (var context = new MOVIES_RELAX_Entities())
            {
                var data = GetUser(code);
                context.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                context.USERS.Remove(data);
                if (context.SaveChanges() < 1)
                    return "Xoá thất bại";
            }
            return "";
        }
    }
}
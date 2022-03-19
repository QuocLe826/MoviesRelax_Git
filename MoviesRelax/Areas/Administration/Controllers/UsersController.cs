using MoviesRelax.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace MoviesRelax.Areas.Administration.Controllers
{
    public class UsersController : Controller
    {
        private UsersModel _user = new UsersModel();

        #region Login

        private USER_LOGIN ReadAccount()
        {
            var config = ConfigurationManager.AppSettings;
            return new USER_LOGIN { Username = config["Username"].ToString(), Remember = config["Remember"].ToString() == "True" ? true : false };
        }

        private void WriteAccount(string username, bool remember)
        {
            Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
            AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
            KeyValueConfigurationCollection settings = appSettingsSection.Settings;

            settings["Username"].Value = remember == true ? username : "";
            settings["Remember"].Value = remember == true ? "True" : "False";

            configuration.Save();
        }

        public ActionResult ProcessLogin(USER_LOGIN model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }

            WriteAccount(model.Username, model.Remember);

            var result = _user.Login(model.Username, model.Password);
            if (!string.IsNullOrEmpty(result))
            {
                TempData["Message"] = result;
                return View("Login", model);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region CRUD

        public ActionResult AddNew()
        {
            ViewData["UserTypes"] = _user.GetUserTypes();
            return View();
        }

        public ActionResult Edit(string code)
        {
            var model = _user.GetUser(code);
            ViewData["UserTypes"] = _user.GetUserTypes();
            return View(model);
        }

        private void ProcessImage(USER model)
        {
            if (model.PhotoImg != null)
            {
                var path = "~/archives/users/";
                var fileName = Path.GetFileNameWithoutExtension(model.PhotoImg.FileName);
                var extension = Path.GetExtension(model.PhotoImg.FileName);
                var newFile = DateTime.Now.ToString("yymmssffff") + extension;
                model.PhotoPath = path + newFile;
                newFile = Path.Combine(Server.MapPath(path), newFile);
                model.PhotoImg.SaveAs(newFile);
            }
        }

        public ActionResult SaveData(USER model, string type)
        {
            if (!ModelState.IsValid)
            {
                if (type == "A")
                    return View("AddNew", model);
                return View("Edit", model);
            }

            ProcessImage(model);
            var result = _user.SaveData(model, type);

            if (type == "A")
                return RedirectToAction("AddNew", "Users");
            return RedirectToAction("Index", "Users");
        }

        public ActionResult Delete(string code)
        {
            var model = _user.GetUser(code);
            return View(model);
        }

        public ActionResult DeleteData(USER model)
        {
            var result = _user.DeleteData(model.Code);
            if (!string.IsNullOrEmpty(result))
            {
                return View("Delete");
            }
            return RedirectToAction("Index", "Users");
        }

        #endregion

        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNum = 0;

            if (page == null)
                page = 1;

            pageNum = page ?? 1;
            var model = _user.GetUsers().ToPagedList(pageNum, pageSize);

            return View(model);
        }

        // GET: Administration/Users
        public ActionResult Login()
        {
            var model = ReadAccount();
            return View(model);
        }
        
    }
}
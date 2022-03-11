using MoviesRelax.Areas.Administration.Models;
using MoviesRelax.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MoviesRelax.Areas.Administration.Controllers
{
    public class UsersController : Controller
    {
        private UsersModel _user = new UsersModel();

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

        // GET: Administration/Users
        public ActionResult Login()
        {
            var model = ReadAccount();
            return View(model);
        }

        public ActionResult ProcessLogin(USER_LOGIN model)
        {
            if(!ModelState.IsValid)
            {
                return View("Login", model);
            }

            WriteAccount(model.Username, model.Remember);

            var result = _user.Login(model.Username, model.Password);
            if(!string.IsNullOrEmpty(result))
            {
                TempData["Message"] = result;
                return View("Login", model);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
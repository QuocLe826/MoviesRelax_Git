using MoviesRelax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MoviesRelax.Areas.Administration.Controllers
{
    public class SubTitleController : Controller
    {
        private SubTitleModel _model = new SubTitleModel();

        // GET: Administration/SubTitle
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNum = 0;

            if (page == null)
                page = 1;

            pageNum = page ?? 1;

            var data = _model.GetSubTitles().ToPagedList(pageNum, pageSize);
            return View(data);
        }

        public ActionResult AddNew()
        {
            return View();
        }

        public ActionResult Edit(string code)
        {
            var model = _model.GetSubTitle(code);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult SaveData(SUBTITLE model, string type)
        {
            if (!ModelState.IsValid)
            {
                if (type == "A")
                    return View("AddNew", model);
                return View("Edit", model);
            }
            var result = _model.SaveData(model, type);

            if (type == "A")
                return RedirectToAction("AddNew", "SubTitle");
            return RedirectToAction("Index", "SubTitle");
        }

        public ActionResult Delete(string code)
        {
            var model = _model.GetSubTitle(code);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult DeleteData(SUBTITLE model)
        {
            var result = _model.DeleteData(model.Code);
            if (!string.IsNullOrEmpty(result))
            {
                return View("Delete");
            }
            return RedirectToAction("Index", "SubTitle");
        }
    }
}
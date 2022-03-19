﻿using MoviesRelax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;

namespace MoviesRelax.Areas.Administration.Controllers
{
    public class DirectorController : Controller
    {
        private DirectorModel _model = new DirectorModel();

        private void ProcessImage(DIRECTOR model)
        {
            if (model.PhotoImg != null)
            {
                var path = "~/archives/directors/";
                var fileName = Path.GetFileNameWithoutExtension(model.PhotoImg.FileName);
                var extension = Path.GetExtension(model.PhotoImg.FileName);
                var newFile = DateTime.Now.ToString("yymmssffff") + extension;
                model.PhotoPath = path + newFile;
                newFile = Path.Combine(Server.MapPath(path), newFile);
                model.PhotoImg.SaveAs(newFile);
            }
        }

        // GET: Administration/Actor
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNum = 0;

            if (page == null)
                page = 1;
            
            pageNum = page ?? 1;

            var data = _model.GetDirectors().ToPagedList(pageNum, pageSize);
            return View(data);
        }

        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string code)
        {
            var model = _model.GetDirector(code);
            if (model == null)
            {
                return HttpNotFound();
            }   
            return View(model);
        }

        public ActionResult SaveData(DIRECTOR model, string type)
        {
            if (!ModelState.IsValid)
            {
                if (type == "A")
                    return View("AddNew", model);
                return View("Edit", model);
            }

            ProcessImage(model);
            var result = _model.SaveData(model, type);

            if (type == "A")
                return RedirectToAction("AddNew", "Director");
            return RedirectToAction("Index", "Director");
        }

        public ActionResult Delete(string code)
        {
            var model = _model.GetDirector(code);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult DeleteData(ACTOR model)
        {
            var result = _model.DeleteData(model.Code);
            if (!string.IsNullOrEmpty(result))
            {
                return View("Delete");
            }
            return RedirectToAction("Index", "Director");
        }
    }
}
using MoviesRelax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MoviesRelax.Areas.Administration.Controllers
{
    public class MovieGenresController : Controller
    {
        private MovieGenreModel _model = new MovieGenreModel();

        // GET: Administration/MovieGenres
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int curPage = 0;

            if (page == null)
                page = 1;

            curPage = (page ?? 1);
            var data = _model.GetMovieGenres().ToPagedList(curPage, pageSize);
            return View(data);
        }

        public ActionResult AddNew()
        {
            return View();
        }

        public ActionResult Edit(string code)
        {
            var model = _model.GetMovieGenre(code);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        public ActionResult SaveData(MOVIE_GENRE model, string type)
        {
            if (!ModelState.IsValid)
            {
                if(type == "A")
                    return View("AddNew", model);
                return View("Edit", model);
            }
            var result = _model.SaveData(model, type);

            if(type == "A")
                return RedirectToAction("AddNew", "MovieGenres");
            return RedirectToAction("Index", "MovieGenres");
        }

        public ActionResult Delete(string code)
        {
            var model = _model.GetMovieGenre(code);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        public ActionResult DeleteData(MOVIE_GENRE model)
        {
            var result = _model.DeleteData(model.Code);
            if(!string.IsNullOrEmpty(result))
            {
                return View("Delete");
            }
            return RedirectToAction("Index", "MovieGenres");
        }
    }
}
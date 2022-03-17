using MoviesRelax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRelax.Models
{
    public class MovieGenreModel: EntityModel
    {
        public MOVIE_GENRE GetMovieGenre(string code)
        {
            using (var context = new MOVIES_RELAX_Entities())
            {
                return context.MOVIE_GENRE.Single(x => x.Code == code);
            }
        }

        public List<MOVIE_GENRE> GetMovieGenres()
        {
            var data = new List<MOVIE_GENRE>();
            using (var context = new MOVIES_RELAX_Entities())
            {
                var query = from x in context.MOVIE_GENRE
                             select new
                             {
                                 x.Code,
                                 x.Name,
                                 x.TimeCreated,
                                 TimeUpdated = x.TimeUpdated == null ? x.TimeCreated : x.TimeUpdated
                             };

                foreach (var item in query)
                {
                    data.Add(new MOVIE_GENRE() { Code = item.Code, Name = item.Name, TimeCreated = item.TimeCreated, TimeUpdated = item.TimeUpdated });
                }
            }
            return data;
        }

        public string SaveData(MOVIE_GENRE model, string type)
        {
            var result = "";
            using (var context = new MOVIES_RELAX_Entities())
            {
                if(type == "A")
                {
                    model.Code = GetNewCode();
                    model.TimeCreated = DateTime.Now;
                    context.MOVIE_GENRE.Add(model);
                }
                else
                {
                    var data = context.MOVIE_GENRE.SingleOrDefault(m => m.Code == model.Code);
                    data.Name = model.Name;
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
                var data = GetMovieGenre(code);

                context.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                context.MOVIE_GENRE.Remove(data);
                if (context.SaveChanges() < 1)
                    return "Xoá thất bại";
            }
            return "";
        }
    }
}
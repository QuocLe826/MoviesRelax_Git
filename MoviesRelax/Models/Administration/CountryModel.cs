using MoviesRelax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRelax.Models
{
    public class CountryModel: EntityModel
    {

        public COUNTRY GetCountry(string code)
        {
            using (var context = new MOVIES_RELAX_Entities())
            {
                return context.COUNTRIES.SingleOrDefault(x => x.Code == code);
            }
        }

        public List<COUNTRY> GetCoutries()
        {
            var data = new List<COUNTRY>();
            using (var context = new MOVIES_RELAX_Entities())
            {
                var query = from x in context.COUNTRIES
                       select new
                       {
                          x.Code,
                          x.Name,
                          x.TimeCreated,
                          TimeUpdated = x.TimeUpdated == null ? x.TimeCreated : x.TimeUpdated
                       };
                foreach(var item in query)
                {
                    data.Add(new COUNTRY() { Code = item.Code, Name = item.Name, TimeCreated = item.TimeCreated, TimeUpdated = item.TimeUpdated });
                }
            }
            return data;
        }

        public string SaveData(COUNTRY model, string type)
        {
            var result = "";
            using (var context = new MOVIES_RELAX_Entities())
            {
                if(type == "A")
                {
                    model.Code = GetNewCode();
                    model.TimeCreated = DateTime.Now;
                    context.COUNTRIES.Add(model);
                }
                else
                {
                    var data = context.COUNTRIES.SingleOrDefault(m => m.Code == model.Code);
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
                var data = GetCountry(code);
                context.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                context.COUNTRIES.Remove(data);
                if (context.SaveChanges() < 1)
                    return "Xoá thất bại";
            }
            return "";
        }
    }
}
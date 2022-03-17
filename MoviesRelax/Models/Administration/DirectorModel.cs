﻿using MoviesRelax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRelax.Models
{
    public class DirectorModel: EntityModel
    {
        public List<DIRECTOR> GetDirectors()
        {
            var data = new List<DIRECTOR>();
            using (var context = new MOVIES_RELAX_Entities())
            {
                var query = from x in context.DIRECTORS
                       select new
                       {
                          x.Code,
                          x.Name,
                          x.DOB,
                          x.PlaceOBirth,
                          x.Height,
                          x.Couple,
                          x.Children,
                          x.Prize,
                          x.Descriptions,
                          x.PhotoPath,
                          x.TimeCreated,
                          TimeUpdated = x.TimeUpdated == null ? x.TimeCreated : x.TimeUpdated
                       };
                foreach(var item in query)
                {
                    data.Add(new DIRECTOR()
                    {
                        Code = item.Code,
                        Name = item.Name,
                        DOB = item.DOB,
                        PlaceOBirth = item.PlaceOBirth,
                        Height = item.Height,
                        Couple = item.Couple,
                        Children = item.Children,
                        Prize = item.Prize,
                        Descriptions = item.Descriptions,
                        PhotoPath = item.PhotoPath,
                        TimeCreated = item.TimeCreated,
                        TimeUpdated = item.TimeUpdated
                    });
                }
            }
            return data;
        }

        public DIRECTOR GetDirector(string code)
        {
            using (var context = new MOVIES_RELAX_Entities())
            {
                return context.DIRECTORS.SingleOrDefault(m => m.Code == code);
            }
        }

        public string SaveData(DIRECTOR model, string type)
        {
            var result = "";
            using (var context = new MOVIES_RELAX_Entities())
            {
                if(type == "A")
                {
                    model.Code = GetNewCode();
                    model.Descriptions = model.Descriptions.Trim();
                    model.TimeCreated = DateTime.Now;
                    context.DIRECTORS.Add(model);
                }
                else
                {
                    var data = context.DIRECTORS.Single(x => x.Code == model.Code);

                    data.Name = model.Name;
                    data.DOB = model.DOB;
                    data.PlaceOBirth = model.PlaceOBirth;
                    data.Height = model.Height;
                    data.Couple = model.Couple;
                    data.Children = model.Children;
                    data.Prize = model.Prize;
                    data.Descriptions = model.Descriptions;
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
                var data = context.DIRECTORS.SingleOrDefault(x => x.Code == code);
                context.DIRECTORS.Remove(data);
                if (context.SaveChanges() < 1)
                    return "Xoá thất bại";
            }
            return "";
        }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoviesRelax.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public partial class DIRECTOR
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string PlaceOBirth { get; set; }
        public string Height { get; set; }
        public string Couple { get; set; }
        public string Children { get; set; }
        public string Prize { get; set; }
        public string Descriptions { get; set; }
        public HttpPostedFileBase PhotoImg { get; set; }
        public string PhotoPath { get; set; }
        public Nullable<System.DateTime> TimeCreated { get; set; }
        public Nullable<System.DateTime> TimeUpdated { get; set; }
        public string RoleCode { get; set; }
    }
}

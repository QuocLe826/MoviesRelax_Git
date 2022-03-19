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
    using System.ComponentModel.DataAnnotations;

    public partial class USER
    {
        public string Code { get; set; }
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string Auth { get; set; }
        public HttpPostedFileBase PhotoImg { get; set; }
        public string PhotoPath { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public Nullable<System.DateTime> TimeCreated { get; set; }
        public Nullable<System.DateTime> TimeUpdated { get; set; }
    }
}

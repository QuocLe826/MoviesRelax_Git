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
    
    public partial class MOVIE_COMMENTS
    {
        public string Code { get; set; }
        public string MovieCode { get; set; }
        public string Username { get; set; }
        public string Comments { get; set; }
        public Nullable<System.DateTime> TimeCreated { get; set; }
        public Nullable<System.DateTime> TimeUpdated { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MOVIES_RELAX_Entities : DbContext
    {
        public MOVIES_RELAX_Entities()
            : base("name=MOVIES_RELAX_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<USER> USERS { get; set; }
        public virtual DbSet<USER_LOGIN> USER_LOGIN { get; set; }
        public virtual DbSet<USER_TYPES> USER_TYPES { get; set; }
    }
}

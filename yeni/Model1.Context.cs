﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace yeni
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EgitimKampiEFTravelDbEntities3 : DbContext
    {
        public EgitimKampiEFTravelDbEntities3()
            : base("name=EgitimKampiEFTravelDbEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Guide> Guide { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}

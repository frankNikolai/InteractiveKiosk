﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InteractiveKiosk
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gr691_fnvEntities : DbContext
    {
        public gr691_fnvEntities()
            : base("name=gr691_fnvEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administration> Administration { get; set; }
        public virtual DbSet<AgeGroup> AgeGroup { get; set; }
        public virtual DbSet<Attraction> Attraction { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Basket_Attraction> Basket_Attraction { get; set; }
        public virtual DbSet<Developer> Developer { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Descriptions> Descriptions { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
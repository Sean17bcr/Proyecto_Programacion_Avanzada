﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api_ProyectoWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GimnasioDBEntities : DbContext
    {
        public GimnasioDBEntities()
            : base("name=GimnasioDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Clase> Clase { get; set; }
        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<Inscripcion> Inscripcion { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Rutina> Rutina { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
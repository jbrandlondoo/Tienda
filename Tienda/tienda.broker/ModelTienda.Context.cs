﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tienda.broker
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDDatoEntities : DbContext
    {
        public BDDatoEntities()
            : base("name=BDDatoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categoria> categorias { get; set; }
        public virtual DbSet<ciudad> ciudads { get; set; }
        public virtual DbSet<cliente> clientes { get; set; }
        public virtual DbSet<detalleFactura> detalleFacturas { get; set; }
        public virtual DbSet<factura> facturas { get; set; }
        public virtual DbSet<PERSONA> PERSONAs { get; set; }
        public virtual DbSet<producto> productos { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<telefono> telefonoes { get; set; }
    }
}

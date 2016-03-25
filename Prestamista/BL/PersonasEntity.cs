using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Prestamista.Models;
using System.Data.Entity.Infrastructure;
namespace Prestamista.BL
{
    public partial class PersonasEntity : DbContext
    {
         public virtual DbSet<PersonasViewModel> Personas { get; set; }
         public PersonasEntity()
            : base("name=prestarbdEntities") { }
         //protected override void OnModelCreating(DbModelBuilder modelBuilder)
         //{
         //    throw new UnintentionalCodeFirstException();
         //}

         //public virtual DbSet<PersonasViewModel> Personas { get; set; }
    }
    
}
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prestamista
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            this.Creditos = new HashSet<Creditos>();
        }
    
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public int AreaId { get; set; }
        public int EstadoId { get; set; }
        public byte EstRegistro { get; set; }
    
        public virtual Areas Areas { get; set; }
        public virtual TEstados TEstados { get; set; }
        public virtual Personas Personas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Creditos> Creditos { get; set; }
    }
}
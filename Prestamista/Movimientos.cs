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
    
    public partial class Movimientos
    {
        public int Id { get; set; }
        public int CreditoId { get; set; }
        public decimal ValorCancelado { get; set; }
        public decimal ValorPendiente { get; set; }
        public string Observacion { get; set; }
    
        public virtual Prestadores Prestadores { get; set; }
    }
}
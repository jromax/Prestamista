using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Prestamista.Models
{
    public  class RespuestaModel
    {        
        public TipoRespuesta Transaccion { get; set; }
        public  dynamic Datos { get; set; }
        public  string Mensaje { get; set; }
        
        public RespuestaModel()
        {
            Transaccion = TipoRespuesta.Error;
        }        
    }
    public enum TipoRespuesta
    {
        Success = 1,
        Warning = 2,
        Error = 3,
        Default = 1 
    }
}
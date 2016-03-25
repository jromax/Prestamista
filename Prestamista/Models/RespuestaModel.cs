using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Prestamista.Models
{
    public  class RespuestaModel
    {
        public  bool? Respuesta { get; set; }
        public  dynamic Datos { get; set; }
        public  string Mensaje { get; set; }
        public RespuestaModel()
        {
            Respuesta = false;
        }
        public void AsignarViewBagResult()//dynamic viewBack)
        {
            //dynamic res = new ExpandoObject();
            //viewBack.Message = Mensaje;
            //viewBack.Datos = Datos;
            //viewBack.Respuesta = Respuesta;
            //return viewBack;            
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prestamista.BL;
using System.Data;
using System.Data.Entity;
using System.Net;
using Kendo.Mvc.UI;
using Complementos;

namespace Prestamista.Controllers
{
    public class ClientesController : Controller
    {
        private prestarbdEntities db = new prestarbdEntities();        
        
        public ActionResult InsCliente()
        {                 
            return View();
        }

        // POST: Personas/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsCliente(Persona modelPerson)//([Bind(Include = "Id,tipoDocumento,numDocumento,fechaNacimiento,genero,nombres,apellidos,direccion,telefono,observaciones")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(modelPerson);
                db.SaveChanges();
                return RedirectToAction("VerClientes");
            }
            return null;
        }

        public ActionResult VerClientes()
        {
            return View();
        }        
        [HttpPost]
        public ActionResult GetListClientes([DataSourceRequest] DataSourceRequest request)
        {
            var listaPersonas = db.Personas.Where(u => u.Id > 0); //from t in db.Personas select t;
            var result = new DataSourceResult()
            {
                Data = listaPersonas,
                Total = listaPersonas.Count()
            };                        
           //DataSourceResult result = listaPersonas.ToDataSourceResult(request, Persona => new);        
            return Json(result);            
        }        
    }
}
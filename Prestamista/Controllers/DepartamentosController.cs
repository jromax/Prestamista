using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prestamista;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Complementos;
using Prestamista.Models;
using Prestamista.Utils;
namespace Prestamista.Controllers
{
    public class DepartamentosController : Controller
    {
        private bdEntities db = new bdEntities();
        RespuestaModel res = new RespuestaModel();
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult UpdEstadoDepartamento(int Id, int NuevoEstado)
        {
            //ViewBag.Respuesta = null;
            res = new RespuestaModel();
            if (ModelState.IsValid)
            {                
                try
                {
                    var dep = db.Departamentos.Single(u => u.Id == Id);
                    dep.EstRegistro = Convert.ToByte(NuevoEstado);
                    res.Transaccion = TipoRespuesta.Success;
                    res.Mensaje = "Departamento modificado satisfactoriamente";
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    //return RedirectToAction("Index");
                    res.Mensaje = " Mensaje de servidor: " + e.Message;
                }
                finally { }                
            }
            else
            {
                res.Mensaje = "Modelo Incorrecto";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        #region Definicion Entity Framework
        // GET: Departamentos
        public ActionResult Index()
        {
            return View(db.Departamentos.ToList());
        }

        public ActionResult EditarDepartamento(int Id)
        {
            var dep = db.Departamentos.Single(u => u.Id == Id);  
            return View(dep);
        }

        [HttpPost]
        public ActionResult GetListDepartamentos([DataSourceRequest] DataSourceRequest request)
        {
            var lista = db.Departamentos.Where(u => u.Id > 0); //from t in db.Personas select t;
            DataSourceResult result = lista.ToDataSourceResult(request);
            return Json(result);
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamentos departamentos = db.Departamentos.Find(id);
            if (departamentos == null)
            {
                return HttpNotFound();
            }
            return View(departamentos);
        }

        // GET: Departamentos/RegistrarDepartamento
        public ActionResult RegistrarDepartamento()
        {
            return View();
        }

        // GET: Departamentos/RegistrarDepartamento
        public ActionResult RegistrarDepartamentoModalFrm()
        {
            return PartialView("_RegistrarDepartamento");
        }        

        // POST: Registro de Departamento        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarDepartamento([Bind(Include = "Id,Nombre,Sigla,EstRegistro")] Departamentos departamentos)
        {
            res = new RespuestaModel();
            if (ModelState.IsValid)
            {
                db.Departamentos.Add(departamentos);
                db.SaveChanges();
                res.Transaccion = TipoRespuesta.Success;
                res.Mensaje = "Departamento registrado satisfactoriamente";                
                ViewBag.Respuesta = res;
                //res.AsignarViewBagResult(ViewBag);
                return View("Index", db.Departamentos.ToList()); //return RedirectToAction("Index");
            }
            return View(departamentos);
        }

        // POST: Registro de Departamento        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RegistrarDepartamentoModal([Bind(Include = "Id,Nombre,Sigla,EstRegistro")] Departamentos departamentos)
        {
            return Json(new LogicaNegocio().EjecutarRetornandoJson(res =>
            {
                var dep = db.Departamentos.FirstOrDefault(u => u.Nombre == departamentos.Nombre);
                if (dep == null)
                {
                    db.Departamentos.Add(departamentos);
                    db.SaveChanges();
                    res.Transaccion = TipoRespuesta.Success;
                    res.Mensaje = "Departamento registrado satisfactoriamente";
                }
                else
                {
                    res.Transaccion = TipoRespuesta.Warning;
                    res.Mensaje = "Departamento ya fue registrado previamente";
                }
                return res;
            }, ModelState
            ));
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamentos departamentos = db.Departamentos.Find(id);
            if (departamentos == null)
            {
                return HttpNotFound();
            }
            return View(departamentos);
        }

        // POST: Departamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Sigla,EstRegistro")] Departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamentos).State = EntityState.Modified;                                                               
                return View("Index", db.Departamentos.ToList()); //RedirectToAction("Index");
            }
            return View("EditarDepartamento", departamentos);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion Definicion Entity Framework
        
    }
}
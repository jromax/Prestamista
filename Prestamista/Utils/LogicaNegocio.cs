using Prestamista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prestamista.Utils
{
    public class LogicaNegocio : ContextBoundObject
    {
        public RespuestaModel EjecutarRetornandoJson(Func<RespuestaModel, RespuestaModel> func, ModelStateDictionary modelState)
        {
            RespuestaModel res = new RespuestaModel();
            if (!modelState.IsValid)
            {
                res.Transaccion = TipoRespuesta.Warning;
                res.Mensaje = "Algún dato tiene un formato o tipo incorrecto";
                return res; 
            }
            else
            {                
                try
                {
                    return func(res);
                }
                catch (FormatException)
                {
                    res.Transaccion = TipoRespuesta.Error;
                    res.Mensaje = "Generado por formato incorrecto de algún dato";
                    return res;
                }
                //catch (KeyNotFoundException) { throw new KeyNotFoundException(); }
                catch (Exception)
                {
                    res.Transaccion = TipoRespuesta.Error;
                    res.Mensaje = "Generado al interior del contexto de la aplicación";
                    return res;
                }
                finally { }
            }            
        }
        public RespuestaModel EjecutarRetornandoJson(Func<RespuestaModel, RespuestaModel> func )
        {
            RespuestaModel res = new RespuestaModel();
            
                try
                {
                    return func(res);
                }
                catch (FormatException)
                {
                    res.Transaccion = TipoRespuesta.Error;
                    res.Mensaje = "Generado por formato incorrecto de algún dato";
                    return res;
                }
                //catch (KeyNotFoundException) { throw new KeyNotFoundException(); }
                catch (Exception)
                {
                    res.Transaccion = TipoRespuesta.Error;
                    res.Mensaje = "Generado al interior del contexto de la aplicación";
                    return res;
                }
                finally { }
            
        }
    }
}
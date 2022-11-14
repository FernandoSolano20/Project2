using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using Web_API.Controllers;

namespace Web_API.ActionFilters
{
    public class CatalogosActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var bitacoraController = new BitacoraController();
            try
            {
                //Se crea el objeto Bitacora que va a ser enviado a la base de datos
                Bitacora bitacora = new Bitacora();
                //Se obtiene el valor que viene en el body del request
                var baseEntity = (BaseEntity)actionExecutedContext.ActionContext.ActionArguments.First().Value;
                //Se construye el objeto que va a ser enviado al controlador de la Bitacora
                bitacora = construirObjetoBitacora(actionExecutedContext, baseEntity);
                //Una vez construido el objeto bitacora, se envia al Controlador API de tipo Bitacora
                bitacoraController.Post(bitacora);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        private Bitacora construirObjetoBitacora(HttpActionExecutedContext actionExecutedContext, BaseEntity baseEntity)
        {

            Bitacora bitacora = new Bitacora()
            {
                Identificador = generarIdentificadores(actionExecutedContext, baseEntity),
                Verbo = actionExecutedContext.Request.Method.ToString(),
                Accion = actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                Entidad = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                Fecha = DateTime.Now,
                ID_Usuario = obtenerUsuario(actionExecutedContext)
            };

            return bitacora;
        }

        private string obtenerUsuario(HttpActionExecutedContext actionExecutedContext)
        {
            string usuario = "";
            //Se obtiene la lista de Headers (Encabezados) contenidos en el request
            var headers = actionExecutedContext.ActionContext.ControllerContext.Request.Headers;
            //Se verifica si 'usuario' se encuentra dentro de la lista de headers
            if (headers.Contains("usuario"))
            {
                usuario = headers.GetValues("usuario").First();
            }
            return usuario;
        }

        private string generarIdentificadores(HttpActionExecutedContext actionExecutedContext, BaseEntity baseEntity)
        {
            //Cadena donde se va a almacenar el texto con los datos que identifiquen a la entidad afectada
            string txtIdentificadores = "N/A";
            //Se obtiene la lista de Headers (Encabezados) contenidos en el request
            var headers = actionExecutedContext.ActionContext.ControllerContext.Request.Headers;
            //Se verifica si 'identificadores' se encuentra dentro de la lista de headers
            if (headers.Contains("identificadores"))
            {
                txtIdentificadores = "";
                //Obtiene de los encabezados la lista de identificadores
                var identificadores = headers.GetValues("identificadores").First().Split(',');

                //Por cada identificador genera un pequeño texto para identificar la entidad con la que se está trabajando
                foreach (var Id in identificadores)
                {
                    string valor = baseEntity.GetType().GetProperty(Id).GetValue(baseEntity, null).ToString();
                    string texto = $"{Id}: {valor} ";
                    txtIdentificadores += texto;
                }
            }
            return txtIdentificadores;
        }
    }
}
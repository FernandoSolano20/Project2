using CoreAPI;
using CoreAPI.RolManager;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web_API.ActionFilters;

namespace Web_API.Controllers
{

    public class RolController : ApiController
    {
            ApiResponse apiResp = new ApiResponse();
            // GET api/cliente
            // Retrieve
            public IHttpActionResult Get()
            {
                apiResp = new ApiResponse();
                var mng = new RolManager();
                apiResp.Data = mng.RetrieveAll();
            apiResp.Message = "The action was executed";

                return Ok(apiResp);
            }
            // GET api/descuento/5
            // Retrieve by id
            public IHttpActionResult Get(string nombre)
            {
                try
                {
                    var mng = new RolManager();
                    var rol = new Rol
                    {
                        Nombre = nombre
                    };

                    rol = mng.RetrieveById(rol);
                    apiResp = new ApiResponse();
                    apiResp.Data = rol;
                    return Ok(apiResp);
                }
                catch (BusinessException bex)
                {
                    return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MensajeEspanol));
                }
            }
        // POST 
        // CREATE
        [CatalogosActionFilter]

        public IHttpActionResult Post(Rol rol)
            {
                try
                {
                    var mng = new RolManager();
                    mng.Create(rol);

                    apiResp = new ApiResponse();
                    apiResp.Message = "Action was executed.";

                    return Ok(apiResp);
                }
                catch (BusinessException bex)
                {
                    return InternalServerError(new Exception(bex.ExceptionId + "-"
                        + bex.AppMessage.MensajeEspanol));
                }
            }
        // PUT
        // UPDATE
        [CatalogosActionFilter]

        public IHttpActionResult Put(Rol rol)
            {
                try
                {
                    var mng = new RolManager();
                    mng.Update(rol);

                    apiResp = new ApiResponse();
                    apiResp.Message = "Action was executed.";

                    return Ok(apiResp);
                }
                catch (BusinessException bex)
                {
                    return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MensajeEspanol));
                }
            }

        // DELETE ==
        [CatalogosActionFilter]

        public IHttpActionResult Delete(Rol rol)
            {
                try
                {
                    var mng = new RolManager();
                    mng.Delete(rol);

                    apiResp = new ApiResponse();
                    apiResp.Message = "Action was executed.";

                    return Ok(apiResp);
                }
                catch (BusinessException bex)
                {
                    return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MensajeEspanol));
                }
            }
        }
    }

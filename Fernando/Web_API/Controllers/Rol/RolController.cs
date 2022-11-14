using CoreAPI;
using CoreAPI.RolManager;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;

namespace Web_API.Controllers
{
    [EnableCors(origins: "https://localhost:44347/", headers: "*", methods: "*")]
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

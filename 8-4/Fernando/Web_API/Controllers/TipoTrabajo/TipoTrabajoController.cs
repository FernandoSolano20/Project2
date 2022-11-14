using CoreAPI;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.ActionFilters;
using System.Web;
namespace Web_API.Controllers
{
    
    public class TipoTrabajoController : ApiController
    {
        private ApiResponse apiResponse;
        private TipoTrabajoManager manager;
        public IHttpActionResult Get()
        {
            
            manager = new TipoTrabajoManager();
            apiResponse = new ApiResponse();
            apiResponse.Data = manager.RetrieveAll();

            return Ok(apiResponse);
        }

        [CatalogosActionFilter]
        public IHttpActionResult Post(TipoTrabajo tipoTrabajo)
        {
            try
            {

                manager = new TipoTrabajoManager();
                manager.Create(tipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Message = "The action was executed";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var tipoTrabajo = new TipoTrabajo { ID = id };

                manager = new TipoTrabajoManager();
                tipoTrabajo = manager.RetrieveByID(tipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Data = tipoTrabajo;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }

        [CatalogosActionFilter]
        public IHttpActionResult Put(TipoTrabajo tipoTrabajo)
        {
            try
            {
                manager = new TipoTrabajoManager();
                manager.Update(tipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Message = "The action has been executed";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }

        }
        [CatalogosActionFilter]
        public IHttpActionResult Delete(TipoTrabajo tipoTrabajo)
        {
            try
            {
                manager = new TipoTrabajoManager();
                manager.Delete(tipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Message = "The action was executed";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }

        [HttpGet]
        [Route("api/TipoTrabajo/Active")]
        public IHttpActionResult GetActive()
        {
            try
            {
                manager = new TipoTrabajoManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveActive();
                apiResponse.Message = "Action completed successfully";



                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }

        [CatalogosActionFilter]
        [HttpPut]
        [Route("api/TipoTrabajo/UpdateStatus")]
        public IHttpActionResult UpdateStatus(TipoTrabajo tipoTrabajo)
        {
            try
            {
                manager = new TipoTrabajoManager();
                manager.UpdateStatus(tipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Message = "The action has been executed";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }
    }
}

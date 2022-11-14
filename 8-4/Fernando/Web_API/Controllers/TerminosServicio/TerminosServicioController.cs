using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreAPI;
using Entities_POJO;
using Excepciones;
using Web_API.ActionFilters;


namespace Web_API.Controllers
{
    public class TerminosServicioController : ApiController
    {
        private ApiResponse apiResponse;
        private TerminosServicioManager manager;

        //Get all
        public IHttpActionResult Get()
        {
            manager = new TerminosServicioManager();
            apiResponse = new ApiResponse();
            apiResponse.Data = manager.RetrieveAll();

            return Ok(apiResponse);
        }


        //Post
        [CatalogosActionFilter]
        public IHttpActionResult Post(TerminosServicio terminosServicio)
        {
            try
            {

                manager = new TerminosServicioManager();
                manager.Create(terminosServicio);

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

        //Get by: Titulo
        public IHttpActionResult Get(string titulo)
        {
            try
            {
                var terminosServicio = new TerminosServicio { Titulo = titulo };

                manager = new TerminosServicioManager();
                terminosServicio = manager.RetrieveByTitulo(terminosServicio);

                apiResponse = new ApiResponse();
                apiResponse.Data = terminosServicio;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }

        //Put
        [CatalogosActionFilter]
        public IHttpActionResult Put(TerminosServicio terminosServicio)
        {
            try
            {
                manager = new TerminosServicioManager();
                manager.Update(terminosServicio);

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

        //Delete
        [CatalogosActionFilter]
        public IHttpActionResult Delete(TerminosServicio terminosServicio)
        {
            try
            {
                manager = new TerminosServicioManager();
                manager.Delete(terminosServicio);

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

        //Retrieve Estado
        [HttpGet]
        [Route("api/TerminosServicio/Active")]
        public IHttpActionResult GetActive()
        {
            try
            {
                manager = new TerminosServicioManager();

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

        //Update Estado
        [CatalogosActionFilter]
        [HttpPut]
        [Route("api/TerminosServicio/UpdateStatus")]
        public IHttpActionResult UpdateStatus(TerminosServicio terminosServicio)
        {
            try
            {
                manager = new TerminosServicioManager();
                manager.UpdateStatus(terminosServicio);

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

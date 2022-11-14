using CoreAPI.MembresiaManager;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.ActionFilters;

namespace Web_API.Controllers.Membresia
{
    public class MembresiaController : ApiController
    {
        private ApiResponse apiResponse;
        private MembresiaManager manager;
        public IHttpActionResult Get()
        {

            manager = new MembresiaManager();
            apiResponse = new ApiResponse();
            apiResponse.Data = manager.RetrieveAll();

            return Ok(apiResponse);
        }

        [Route("api/Membresia/MembresiaRegular")]
        public IHttpActionResult PostMembresiaRegular(Entities_POJO.Membresia membresia)
        {
            try { 
            
                manager = new MembresiaManager();
                manager.Create(membresia);

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
                var membresia = new Entities_POJO.Membresia { ID = id };

                manager = new MembresiaManager();
                membresia = manager.RetrieveByID(membresia);

                apiResponse = new ApiResponse();
                apiResponse.Data = membresia;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }

        public IHttpActionResult Delete(Entities_POJO.Membresia membresia)
        {
            try
            {
                manager = new MembresiaManager();
                manager.Delete(membresia);

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

        public IHttpActionResult Put(Entities_POJO.Membresia membresia)
        {
            try
            {
                manager = new MembresiaManager();
                manager.Update(membresia);

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

        [HttpGet]
        [Route("api/Membresia/MembresiaActual")]
        public IHttpActionResult GetCurrent(string IdentificacionUsuario)
        {
            try
            {
                var membresia = new Entities_POJO.Membresia()
                {
                    ID_Representante = IdentificacionUsuario
                };

                manager = new MembresiaManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrievePerDate(membresia);
                apiResponse.Message = "Action completed successfully";



                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }

        [HttpPut]
        [Route("api/Membresia/UpdateDate")]
        public IHttpActionResult UpdateDate(Entities_POJO.Membresia membresia)
        {
            try
            {
                manager = new MembresiaManager();
                manager.UpdateDate(membresia);

                apiResponse = new ApiResponse();
                apiResponse.Message = "El pago se ha realizado correctamente";

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

using CoreAPI.Transaccion;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.ActionFilters;

namespace Web_API.Controllers.Transaccion
{
    public class TransaccionController : ApiController
    {
        private ApiResponse apiResponse;
        private TransaccionManager manager;
        public IHttpActionResult Get()
        {

            manager = new TransaccionManager();
            apiResponse = new ApiResponse();
            apiResponse.Data = manager.RetrieveAll();

            return Ok(apiResponse);
        }

        [CatalogosActionFilter]
        public IHttpActionResult Post(Entities_POJO.Transaccion transaccion)
        {
            try
            {

                manager = new TransaccionManager();
                manager.Create(transaccion);

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
                var transaccion = new Entities_POJO.Transaccion { ID = id };

                manager = new TransaccionManager();
                transaccion = manager.RetrieveByID(transaccion);

                apiResponse = new ApiResponse();
                apiResponse.Data = transaccion;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }

        [CatalogosActionFilter]
        public IHttpActionResult Put(Entities_POJO.Transaccion transaccion)
        {
            try
            {
                manager = new TransaccionManager();
                manager.Update(transaccion);

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
        public IHttpActionResult Delete(Entities_POJO.Transaccion transaccion)
        {
            try
            {
                manager = new TransaccionManager();
                manager.Delete(transaccion);

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
    }
}

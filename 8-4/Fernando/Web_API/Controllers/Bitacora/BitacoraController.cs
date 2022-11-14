using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreAPI.BitacoraManager;
using Entities_POJO;
using Excepciones;

namespace Web_API.Controllers
{
    public class BitacoraController : ApiController
    {
        private ApiResponse apiResponse;
        private BitacoraManager manager;

        public IHttpActionResult Get()
        {
            try
            {
                manager = new BitacoraManager();
                var bitacora = manager.RetrieveAll();

                apiResponse = new ApiResponse();
                apiResponse.Data = bitacora;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }

        public IHttpActionResult Post(Bitacora bitacora)
        {
            try
            {

                manager = new BitacoraManager();
                manager.Create(bitacora);

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

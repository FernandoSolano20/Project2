using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.ActionFilters;

namespace Web_API.Controllers.Documento
{
    public class DocumentoController : ApiController
    {
        private ApiResponse apiResponse;
        private CoreAPI.DocumentoManager.DocumentoManager manager;
        public IHttpActionResult Get()
        {

            manager = new CoreAPI.DocumentoManager.DocumentoManager();
            apiResponse = new ApiResponse();
            apiResponse.Data = manager.RetrieveAll();

            return Ok(apiResponse);
        }

        [HttpPost]
        [Route("api/Documento/DocumentoProveedor")]
        public IHttpActionResult Post(Entities_POJO.Documento documento)
        {
            try
            {
                documento.TipoDocumento = TipoDocumento.DOCUMENTO_PROVEEDOR;
                documento.Estado = Estado.ACT;

                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                manager.Create(documento);

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
                var documento = new Entities_POJO.Documento { ID = id };

                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                documento = manager.RetrieveByID(documento);

                apiResponse = new ApiResponse();
                apiResponse.Data = documento;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }

        [HttpGet]
        [Route("api/Documento/ObtenerPorUsuario")]
        public IHttpActionResult Get(string IdentificacionUsuario)
        {
            try
            {
                var documento = new Entities_POJO.Documento {
                    ID_Propietario = IdentificacionUsuario,
                    TipoDocumento = TipoDocumento.DOCUMENTO_PROVEEDOR
                };

                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveByUserID(documento);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MensajeEspanol));
            }
        }
        public IHttpActionResult Put(Entities_POJO.Documento documento)
        {
            try
            {
                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                manager.Update(documento);

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

        public IHttpActionResult Delete(Entities_POJO.Documento documento)
        {
            try
            {
                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                manager.Delete(documento);

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
        [Route("api/Documento/Active")]
        public IHttpActionResult GetActive()
        {
            try
            {
                manager = new CoreAPI.DocumentoManager.DocumentoManager();

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

        [HttpPut]
        [Route("api/Documento/UpdateStatus")]
        public IHttpActionResult UpdateStatus(Entities_POJO.Documento documento)
        {
            try
            {
                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                manager.UpdateStatus(documento);

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

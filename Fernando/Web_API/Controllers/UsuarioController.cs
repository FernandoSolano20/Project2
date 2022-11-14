using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CoreAPI.EmpresaManager;
using CoreAPI.User;
using Entities_POJO;
using Excepciones;
using Newtonsoft.Json.Linq;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers.User
{
    public class UsuarioController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();
        public async Task<IHttpActionResult> Get()
        {
            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new UsuarioManager();
                apiResponse.Data = mng.RetrieveAll();
                return apiResponse;
            });
            return Ok(response);
        }

        public async Task<IHttpActionResult> Post(Usuario entity)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new UsuarioManager();
                    mng.Create(entity);

                    apiResponse = new ApiResponse();
                    apiResponse.Message = "Action was executed.";
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.Format()));
            }
        }
        [HttpPost]
        [Route("api/Usuario/OferenteFisico")]
        public async Task<IHttpActionResult> CreateOferenteFisico([FromBody]JObject data)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var empresa = data["empresa"].ToObject<Empresa>();
                    var usuario = data["usuario"].ToObject<Usuario>();
                    var mng = new UsuarioManager();
                    mng.CreateOferenteFisico(empresa, usuario);

                    apiResponse = new ApiResponse();
                    apiResponse.Message = "Action was executed.";
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.Format()));
            }
        }

        [HttpPost]
        [Route("api/Usuario/OferenteJuridico")]
        public async Task<IHttpActionResult> CreateOferenteJuridico([FromBody]JObject data)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var empresa = data["empresa"].ToObject<Empresa>();
                    var usuario = data["usuario"].ToObject<Usuario>();
                    var mng = new UsuarioManager();
                    mng.CreateOferenteJuridico(empresa, usuario);

                    apiResponse = new ApiResponse();
                    apiResponse.Message = "Action was executed.";
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.Format()));
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new UsuarioManager();
                    apiResponse.Data = mng.RetrieveById(new Usuario()
                    {
                        Identificacion = id
                    });
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.Format()));
            }
        }

        public async Task<IHttpActionResult> Get(string email)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new UsuarioManager();
                    apiResponse.Data = mng.RetrieveByEmail(new Usuario()
                    {
                        Email = email
                    });
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.Format()));
            }
        }

        public async Task<IHttpActionResult> Put(Usuario entity)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new UsuarioManager();
                    mng.Update(entity);

                    apiResponse = new ApiResponse();
                    apiResponse.Message = "Action was executed.";
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.Format()));
            }
        }

        public async Task<IHttpActionResult> Delete(Usuario entity)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new UsuarioManager();
                    mng.Delete(entity);

                    apiResponse = new ApiResponse();
                    apiResponse.Message = "Action was executed.";
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.Format()));
            }
        }
    }
}

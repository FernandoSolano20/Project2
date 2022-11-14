using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CoreAPI.EmpresaManager;
using Entities_POJO;
using Excepciones;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers
{
    public class EmpresaController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();
        public async Task<IHttpActionResult> Get()
        {
            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new EmpresaManager();
                apiResponse.Data = mng.RetrieveAll();
                return apiResponse;
            });
            return Ok(response);
        }

        public async Task<IHttpActionResult> Post(Empresa entity)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new EmpresaManager();
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
        [HttpGet]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new EmpresaManager();
                    apiResponse.Data = mng.RetrieveById(new Empresa()
                    {
                        Cedula = id
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

        public async Task<IHttpActionResult> Put(Empresa entity)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new EmpresaManager();
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

        public async Task<IHttpActionResult> Delete(Empresa entity)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new EmpresaManager();
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

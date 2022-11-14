using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using CoreAPI.LocalizacionManager;
using CoreAPI.User;
using Entities_POJO;

namespace Web_API.Controllers
{
    public class LocalizacionController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();
        [HttpGet]
        public async Task<IHttpActionResult> ObtenerProvincias()
        {
            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new LocalizacionManager();
                apiResponse.Data = mng.ObtenerProvincias();
                return apiResponse;
            });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerCantones(string provincia)
        {
            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new LocalizacionManager();
                apiResponse.Data = mng.ObtenerCantonesPorProvincia(provincia);
                return apiResponse;
            });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObtenerDistritos(string provincia, string canton)
        {
            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new LocalizacionManager();
                apiResponse.Data = mng.ObtenerDistritoPorCanton(provincia, canton);
                return apiResponse;
            });
            return Ok(response);
        }
    }
}

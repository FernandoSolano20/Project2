using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CoreAPI.MonedaManager;
using Entities_POJO;

namespace Web_API.Controllers
{
    public class MonedaController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();
        [HttpGet, Route("api/Moneda/GetPaises")]
        public async Task<IHttpActionResult> GetPaises()
        {
            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new MonedaManager();
                apiResponse.Data = mng.ObtenerMonedaPaises();
                return apiResponse;
            });
            return Ok(response);
        }

        [HttpGet, Route("api/Moneda/ObtenerMonedaValor")]
        public async Task<IHttpActionResult> ObtenerMonedaValor()
        {
            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new MonedaManager();
                apiResponse.Data = mng.ObtenerMonedaValor();
                return apiResponse;
            });
            return Ok(response);
        }
    }
}

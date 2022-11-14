using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CoreAPI.LocalizacionManager;
using Entities_POJO;

namespace Web_API.Controllers
{
    public class PaisController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();
        [HttpGet]
        public async Task<IHttpActionResult> ObtenerPaises()
        {
            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new LocalizacionManager();
                apiResponse.Data = mng.ObtenerPaises();
                return apiResponse;
            });
            return Ok(response);
        }
    }
}

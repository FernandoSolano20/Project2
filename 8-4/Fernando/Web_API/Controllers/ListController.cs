using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CoreAPI.ListManager;
using CoreAPI.User;
using Entities_POJO;
using Excepciones;
using POJO_Entities.Entities;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers
{
    public class ListController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    apiResponse = new ApiResponse();
                    var mng = new ListManager(id);
                    var option = new OptionList
                    {
                        ListId = id
                    };
                    apiResponse.Data = mng.RetrieveById(option);
                    return apiResponse;
                });
                return Ok(response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.Format()));
            }
        }
    }
}

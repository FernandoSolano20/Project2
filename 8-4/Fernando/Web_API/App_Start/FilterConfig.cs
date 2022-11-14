using System.Web;
using System.Web.Mvc;
using Web_API.ActionFilters;

namespace Web_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

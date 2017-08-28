using PublicServiceRequest.Admin.BLL.Models;
using System.Web;
using System.Web.Mvc;

namespace PublicServiceRequest.Admin.Service
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

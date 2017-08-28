
using PublicServiceRequest.Admin.BLL.Models;
using System.Web.OData;

namespace PublicServiceRequest.Admin.Service.Controllers
{
    //apply authorization attribute to all controllers that inherit this class
    [CustomAuthorize(Roles = @"MIAMIDADE\(PA) AS_PSR_SecG_AdminModule")]
    public class BaseODataController : ODataController
    {

    }
}
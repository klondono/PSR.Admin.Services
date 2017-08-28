using PublicServiceRequest.Admin.BLL.ErrorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PublicServiceRequest.Admin.BLL.Models
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var unauthorizedUser = actionContext.RequestContext.Principal.Identity.Name;
            throw new PSRAdminException(ErrorMessages.UnauthorizedAccess.Unauthorized(unauthorizedUser));
        }

    }
}

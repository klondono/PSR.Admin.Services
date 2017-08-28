using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace PublicServiceRequest.Admin.BLL.ErrorModel
{
    public static class ApiControllerExtension
    {
        public static HttpResponseMessage CreateHttpResponseMessage(this ODataController oDataController, PSRAdminException e)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            response.Content = new StringContent(e.Message);

            return response;
        }

        public static HttpResponseMessage CreateHttpResponseMessage(this ApiController apiController, PSRAdminException e)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            response.Content = new StringContent(e.Message);

            return response;
        }
    }
}

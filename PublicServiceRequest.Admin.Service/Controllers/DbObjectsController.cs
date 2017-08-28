using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using PublicServiceRequest.Admin.BLL.Models;
using PublicServiceRequest.Admin.DAL.Models;
using PublicServiceRequest.Admin.Common.Models;
using PublicServiceRequest.Admin.BLL.ErrorModel;

namespace PublicServiceRequest.Admin.Service.Controllers
{
    public class DbObjectsController : BaseODataController
    {
        private readonly DbObjectBLL _dbObjectBLL;


        private PAGeneralDb db = new PAGeneralDb();

        public DbObjectsController(DbObjectBLL dbObjectBLL)
        {
            if (dbObjectBLL != null)
            {
                _dbObjectBLL = dbObjectBLL;
            }
            else
            {
                throw new PSRAdminException("DbObjectBLL is null.");
            }
        }

        // GET: odata/ServiceTypes
        [EnableQuery(MaxExpansionDepth = 5)]
        public IHttpActionResult GetDbObjects()
        {
            return Ok(_dbObjectBLL.GetDbObjects());
        }

        // GET: odata/ServiceTypes(5)
        public IHttpActionResult GetDbObject([FromODataUri] int? key)
        {
            return Ok(_dbObjectBLL.Find(key));
        }
    }
}
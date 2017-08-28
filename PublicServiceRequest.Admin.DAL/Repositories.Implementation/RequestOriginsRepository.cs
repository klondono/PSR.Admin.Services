using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PublicServiceRequest.Admin.DAL.Models;
using PublicServiceRequest.Admin.BLL.Repositories.Interface;
using PublicServiceRequest.Admin.Common.Models;

namespace PublicServiceRequest.Admin.DAL.Repositories.Implementation
{
    public class RequestOriginsRepository : IRequestOriginsRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<RequestOrigin> Get()
        {
            return db.RequestOrigins;
        }

        public IQueryable<RequestOrigin> Find(int? key)
        {
            return db.RequestOrigins.Where(requestOrigin => requestOrigin.RequestOriginID == key);
        }

    }
}

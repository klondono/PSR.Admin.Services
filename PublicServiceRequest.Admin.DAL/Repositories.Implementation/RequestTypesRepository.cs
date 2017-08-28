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
    public class RequestTypesRepository : IRequestTypesRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<RequestType> Get()
        {
            return db.RequestTypes;
        }

        public IQueryable<RequestType> Find(int? key)
        {
            return db.RequestTypes.Where(requestType => requestType.RequestTypeID == key);
        }

    }
}

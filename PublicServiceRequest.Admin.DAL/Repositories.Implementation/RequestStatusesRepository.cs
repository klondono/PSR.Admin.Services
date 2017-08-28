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
    public class RequestStatusesRepository : IRequestStatusesRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<RequestStatus> Get()
        {
            return db.RequestStatuses;
        }

        public IQueryable<RequestStatus> Find(int? key)
        {
            return db.RequestStatuses.Where(requestStatus => requestStatus.RequestStatusID == key);
        }

    }
}

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
    public class RequestPrioritiesRepository : IRequestPrioritiesRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<RequestPriority> Get()
        {
            return db.RequestPriorities;
        }

        public IQueryable<RequestPriority> Find(int? key)
        {
            return db.RequestPriorities.Where(requestPriority => requestPriority.RequestPriorityID == key);
        }

    }
}

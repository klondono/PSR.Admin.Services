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
    public class ServiceTypeOwnerGroupsRepository : IServiceTypeOwnerGroupsRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<ServiceTypeOwnerGroup> Get()
        {
            return db.ServiceTypeOwnerGroups;
        }

        public IQueryable<ServiceTypeOwnerGroup> Find(Guid? key)
        {
            return db.ServiceTypeOwnerGroups.Where(serviceTypeOwnerGroups => serviceTypeOwnerGroups.ServiceTypeOwnerGroupID == key);
        }

    }
}

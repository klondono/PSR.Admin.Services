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
    public class ServiceTypeOwnerGroupLocationsRepository : IServiceTypeOwnerGroupLocationsRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<ServiceTypeOwnerGroupLocation> Get()
        {
            return db.ServiceTypeOwnerGroupLocations;
        }

        public IQueryable<ServiceTypeOwnerGroupLocation> Find(int? key)
        {
            return db.ServiceTypeOwnerGroupLocations.Where(serviceTypeOwnerGroupLocation => serviceTypeOwnerGroupLocation.ServiceTypeOwnerGroupLocationID == key);
        }

    }
}

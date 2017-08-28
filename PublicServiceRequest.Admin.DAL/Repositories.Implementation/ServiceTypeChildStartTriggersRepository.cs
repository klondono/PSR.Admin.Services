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
    public class ServiceTypeChildStartTriggersRepository : IServiceTypeChildStartTriggersRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<ServiceTypeChildStartTrigger> Get()
        {
            return db.ServiceTypeChildStartTriggers;
        }

        public IQueryable<ServiceTypeChildStartTrigger> Find(int? key)
        {
            return db.ServiceTypeChildStartTriggers.Where(serviceTypeChildStartTrigger => serviceTypeChildStartTrigger.ServiceTypeChildStartTriggerID == key);
        }

    }
}

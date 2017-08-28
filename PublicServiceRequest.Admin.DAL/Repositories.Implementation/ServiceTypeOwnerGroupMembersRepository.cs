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
    public class ServiceTypeOwnerGroupMembersRepository : IServiceTypeOwnerGroupMembersRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<ServiceTypeOwnerGroupMember> Get()
        {
            return db.ServiceTypeOwnerGroupMembers;
        }

        public IQueryable<ServiceTypeOwnerGroupMember> Find(int? key)
        {
            return db.ServiceTypeOwnerGroupMembers.Where(serviceTypeOwnerGroupMember => serviceTypeOwnerGroupMember.ServiceTypeOwnerGroupMemberID == key);
        }

    }
}

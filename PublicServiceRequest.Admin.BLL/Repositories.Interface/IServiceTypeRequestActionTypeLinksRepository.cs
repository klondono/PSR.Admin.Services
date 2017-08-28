using PublicServiceRequest.Admin.BLL.Models;
using PublicServiceRequest.Admin.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServiceRequest.Admin.BLL.Repositories.Interface
{
    public interface IServiceTypeRequestActionTypeLinksRepository
    {
        IQueryable<ServiceTypeRequestActionTypeLink> Get();
        IQueryable<ServiceTypeRequestActionTypeLink> Find(int? key);
        IQueryable<ServiceTypeRequestActionTypeLink> AddOrUpdate(int serviceTypeID, List<ServiceTypeActionTypeLinkUpdateModel> actionTypeLinksToBeUpdated, List<int> actionTypeLinkIdsToBeDeleted);
    }
}

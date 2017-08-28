using PublicServiceRequest.Admin.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData;

namespace PublicServiceRequest.Admin.BLL.Repositories.Interface
{
    public interface IServiceTypesRepository
    {
        IQueryable<ServiceType> Get();
        ServiceType Find(int? key);
        int Create(ServiceType serviceType);
        int Clone(int serviceTypeID);
        void SavePatch();
        bool IsParent(int? key);
        bool BusinessAreaIsVisibleOnPSRCreation(Guid? key);
        //IQueryable<int> Delete(ServiceType serviceType);
    }
}

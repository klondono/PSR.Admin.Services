using PublicServiceRequest.Admin.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServiceRequest.Admin.BLL.Repositories.Interface
{
    public interface IServiceTypeCustomFieldsRepository
    {
        IQueryable<ServiceTypeCustomField> Get();
        ServiceTypeCustomField Find(int? key);
        int Create(ServiceTypeCustomField serviceTypeCustomField);
        void SavePatch();
        bool InputSequenceExists(ServiceTypeCustomField serviceTypeCustomField);
        void Delete(ServiceTypeCustomField serviceTypeCustomField);
    }
}

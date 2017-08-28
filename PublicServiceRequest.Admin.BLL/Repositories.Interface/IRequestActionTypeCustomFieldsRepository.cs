using PublicServiceRequest.Admin.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServiceRequest.Admin.BLL.Repositories.Interface
{
    public interface IRequestActionTypeCustomFieldsRepository
    {
        IQueryable<RequestActionTypeCustomField> Get();
        RequestActionTypeCustomField Find(int? key);
        int Create(RequestActionTypeCustomField actionTypeCustomField);
        void SavePatch();
        bool InputSequenceExists(RequestActionTypeCustomField actionTypeCustomField);
        void Delete(RequestActionTypeCustomField actionTypeCustomField);
    }
}

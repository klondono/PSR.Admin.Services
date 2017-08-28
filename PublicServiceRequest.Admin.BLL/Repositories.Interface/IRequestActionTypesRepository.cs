using PublicServiceRequest.Admin.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServiceRequest.Admin.BLL.Repositories.Interface
{
    public interface IRequestActionTypesRepository
    {
        IQueryable<RequestActionType> Get();
        RequestActionType Find(int? key);
        int Create(RequestActionType requestActionType);
        void SavePatch();
        void Delete(RequestActionType requestActionType);
    }
}

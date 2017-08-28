using PublicServiceRequest.Admin.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData;

namespace PublicServiceRequest.Admin.BLL.Repositories.Interface
{
    public interface IDbObjectsRepository
    {
        IQueryable<DbObject> Get();
        DbObject Find(int? key);
    }
}

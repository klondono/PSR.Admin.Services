using PublicServiceRequest.Admin.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServiceRequest.Admin.BLL.Repositories.Interface
{
    public interface IRequestPrioritiesRepository
    {
        IQueryable<RequestPriority> Get();
        IQueryable<RequestPriority> Find(int? key);
    }
}

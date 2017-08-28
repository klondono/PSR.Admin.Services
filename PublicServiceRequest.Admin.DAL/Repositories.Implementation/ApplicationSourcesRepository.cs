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
    public class ApplicationSourcesRepository : IApplicationSourcesRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<ApplicationSource> Get()
        {
            return db.ApplicationSources;
        }

        public IQueryable<ApplicationSource> Find(int? key)
        {
            return db.ApplicationSources.Where(applicationSource => applicationSource.ApplicationSourceID == key);
        }

    }
}

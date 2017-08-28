using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PublicServiceRequest.Admin.DAL.Models;
using PublicServiceRequest.Admin.BLL.Repositories.Interface;
using PublicServiceRequest.Admin.Common.Models;
using PublicServiceRequest.Admin.BLL.ErrorModel;
using System.Web.OData;
using PublicServiceRequest.Admin.BLL.Helpers;
using System.Web;

namespace PublicServiceRequest.Admin.DAL.Repositories.Implementation
{
    public class DbObjectsRepository : IDbObjectsRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<DbObject> Get()
        {
            return db.DbObjects;
        }

        public DbObject Find(int? key)
        {
            if (key == 0)
            {
                return new DbObject();
            }
            return db.DbObjects.Where(x => x.ObjectId == key).FirstOrDefault();
        }
    }
}

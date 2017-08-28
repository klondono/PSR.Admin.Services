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
    public class RequestFolioTypesRepository : IRequestFolioTypesRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<RequestFolioType> Get()
        {
            return db.RequestFolioTypes;
        }

        public IQueryable<RequestFolioType> Find(int? key)
        {
            return db.RequestFolioTypes.Where(requestFolioType => requestFolioType.RequestFolioTypeID == key);
        }

    }
}

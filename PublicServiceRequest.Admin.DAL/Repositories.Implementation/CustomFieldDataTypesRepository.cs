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
    public class CustomFieldDataTypesRepository : ICustomFieldDataTypesRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<CustomFieldDataType> Get()
        {
            return db.CustomFieldDataTypes;
        }

        public IQueryable<CustomFieldDataType> Find(int? key)
        {
            return db.CustomFieldDataTypes.Where(customFieldDataType => customFieldDataType.CustomFieldDataTypeID == key);
        }

    }
}

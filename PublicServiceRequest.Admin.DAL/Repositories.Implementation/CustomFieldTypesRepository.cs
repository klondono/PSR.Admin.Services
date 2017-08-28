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
    public class CustomFieldTypesRepository : ICustomFieldTypesRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<CustomFieldType> Get()
        {
            return db.CustomFieldTypes;
        }

        public IQueryable<CustomFieldType> Find(int? key)
        {
            return db.CustomFieldTypes.Where(customFieldType => customFieldType.CustomFieldTypeID == key);
        }

    }
}

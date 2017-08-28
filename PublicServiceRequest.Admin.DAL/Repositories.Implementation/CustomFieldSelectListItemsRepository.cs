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
    public class CustomFieldSelectListItemsRepository : ICustomFieldSelectListItemsRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<CustomFieldSelectListItem> Get()
        {
            return db.CustomFieldSelectListItems;
        }

        public IQueryable<CustomFieldSelectListItem> Find(int? key)
        {
            return db.CustomFieldSelectListItems.Where(customFieldSelectListItems => customFieldSelectListItems.CustomFieldSelectListItemID == key);
        }

    }
}

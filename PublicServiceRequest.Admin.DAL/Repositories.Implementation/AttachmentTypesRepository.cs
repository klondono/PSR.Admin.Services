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
    public class AttachmentTypesRepository : IAttachmentTypesRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<AttachmentType> Get()
        {
            return db.AttachmentTypes;
        }

        public IQueryable<AttachmentType> Find(int? key)
        {
            return db.AttachmentTypes.Where(attachmentType => attachmentType.AttachmentTypeID == key);
        }

    }
}

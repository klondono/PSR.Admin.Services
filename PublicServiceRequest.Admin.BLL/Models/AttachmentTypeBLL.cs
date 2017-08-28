namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class AttachmentTypeBLL : BaseModelBLL
    {
        private readonly IAttachmentTypesRepository _attachmentTypeRepository;
        public AttachmentTypeBLL(IAttachmentTypesRepository attachmentTypesRepository)
        {
            if (attachmentTypesRepository != null)
            {
                _attachmentTypeRepository = attachmentTypesRepository;
            }
            else
            {
                throw new ArgumentNullException("IAttachmentTypesRepository is null.");
            }
        }
        public int AttachmentTypeID { get; set; }

        public int ServiceTypeID { get; set; }

        [StringLength(50)]
        public string AttachmentTypeName { get; set; }

        [StringLength(255)]
        public string AttachmentDescription { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public IQueryable<AttachmentType> GetAttachmentTypes()
        {
            return _attachmentTypeRepository.Get();
        }

        public IQueryable<AttachmentType> Find(int? key)
        {
            return _attachmentTypeRepository.Find(key);
        }
    }
}

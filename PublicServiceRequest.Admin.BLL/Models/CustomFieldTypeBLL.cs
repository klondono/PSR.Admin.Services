namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class CustomFieldTypeBLL : BaseModelBLL
    {
        private readonly ICustomFieldTypesRepository _customFieldTypeRepository;
        public CustomFieldTypeBLL(ICustomFieldTypesRepository customFieldTypesRepository)
        {
            if (customFieldTypesRepository != null)
            {
                _customFieldTypeRepository = customFieldTypesRepository;
            }
            else
            {
                throw new ArgumentNullException("ICustomFieldTypesRepository is null.");
            }
        }

        public int CustomFieldTypeID { get; set; }

        [StringLength(50)]
        public string CustomFieldTypeName { get; set; }

        [StringLength(500)]
        public string CustomFieldTypeDescription { get; set; }

        public bool? AllowEditFlag { get; set; }

        public virtual ICollection<CustomFieldSelectListItem> CustomFieldSelectListItems { get; set; }

        public virtual ICollection<ServiceTypeCustomField> ServiceTypeCustomFields { get; set; }

        public virtual ICollection<RequestActionTypeCustomField> RequestActionTypeCustomFields { get; set; }

        public IQueryable<CustomFieldType> GetCustomFieldTypes()
        {
            return _customFieldTypeRepository.Get();
        }

        public IQueryable<CustomFieldType> Find(int? key)
        {
            return _customFieldTypeRepository.Find(key);
        }
    }
}

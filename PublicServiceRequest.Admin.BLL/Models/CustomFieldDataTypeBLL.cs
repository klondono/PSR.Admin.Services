namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class CustomFieldDataTypeBLL : BaseModelBLL
    {
        private readonly ICustomFieldDataTypesRepository _customFieldDataTypeRepository;
        public CustomFieldDataTypeBLL(ICustomFieldDataTypesRepository customFieldDataTypesRepository)
        {
            if (customFieldDataTypesRepository != null)
            {
                _customFieldDataTypeRepository = customFieldDataTypesRepository;
            }
            else
            {
                throw new ArgumentNullException("ICustomFieldDataTypesRepository is null.");
            }
        }

        public int CustomFieldDataTypeID { get; set; }

        [StringLength(50)]
        public string CustomFieldDataTypeName { get; set; }

        [StringLength(255)]
        public string CustomFieldDataTypeDescription { get; set; }

        [StringLength(2000)]
        public string RegularExpression { get; set; }

        [StringLength(1000)]
        public string ErrorMessage { get; set; }

        public virtual ICollection<ServiceTypeCustomField> ServiceTypeCustomFields { get; set; }

        public virtual ICollection<RequestActionTypeCustomField> RequestActionTypeCustomFields { get; set; }

        public IQueryable<CustomFieldDataType> GetCustomFieldDataTypes()
        {
            return _customFieldDataTypeRepository.Get();
        }

        public IQueryable<CustomFieldDataType> Find(int? key)
        {
            return _customFieldDataTypeRepository.Find(key);
        }
    }
}

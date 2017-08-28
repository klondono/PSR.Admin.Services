namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class CustomFieldSelectListItemBLL : BaseModelBLL
    {
        private readonly ICustomFieldSelectListItemsRepository _customFieldSelectListItemRepository;
        public CustomFieldSelectListItemBLL(ICustomFieldSelectListItemsRepository customFieldSelectListItemsRepository)
        {
            if (customFieldSelectListItemsRepository != null)
            {
                _customFieldSelectListItemRepository = customFieldSelectListItemsRepository;
            }
            else
            {
                throw new ArgumentNullException("ICustomFieldSelectListItemsRepository is null.");
            }
        }
        public int CustomFieldSelectListItemID { get; set; }

        public int CustomFieldTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomFieldSelectListItemLabel { get; set; }

        [Required]
        [StringLength(1000)]
        public string CustomFieldSelectListItemValue { get; set; }

        public int ListSequence { get; set; }

        public virtual CustomFieldType CustomFieldType { get; set; }

        public IQueryable<CustomFieldSelectListItem> GetCustomFieldSelectListItems()
        {
            return _customFieldSelectListItemRepository.Get();
        }

        public IQueryable<CustomFieldSelectListItem> Find(int? key)
        {
            return _customFieldSelectListItemRepository.Find(key);
        }
    }
}

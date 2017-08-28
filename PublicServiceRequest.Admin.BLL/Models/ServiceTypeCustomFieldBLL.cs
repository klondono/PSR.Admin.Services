namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using ErrorModel;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.OData;

    public partial class ServiceTypeCustomFieldBLL : BaseModelBLL
    {
        private readonly IServiceTypeCustomFieldsRepository _serviceTypeCustomFieldRepository;
        public ServiceTypeCustomFieldBLL(IServiceTypeCustomFieldsRepository serviceTypeCustomFieldsRepository)
        {
            if (serviceTypeCustomFieldsRepository != null)
            {
                _serviceTypeCustomFieldRepository = serviceTypeCustomFieldsRepository;
            }
            else
            {
                throw new ArgumentNullException("IServiceTypeCustomFieldsRepository is null.");
            }
        }
        public int ServiceTypeCustomFieldID { get; set; }

        public int? ServiceTypeID { get; set; }

        public int? CustomFieldTypeID { get; set; }

        public int? CustomFieldDataTypeID { get; set; }

        [StringLength(50)]
        public string LabelName { get; set; }

        [StringLength(50)]
        public string PlaceholderText { get; set; }

        [StringLength(7)]
        public string TextAlignment { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? InputSequence { get; set; }

        public bool? RequiredFlag { get; set; }

        [StringLength(255)]
        public string TooltipMessage { get; set; }

        [StringLength(25)]
        public string GroupingIdentifier1 { get; set; }

        [StringLength(25)]
        public string GroupingIdentifier2 { get; set; }

        public virtual CustomFieldDataType CustomFieldDataType { get; set; }

        public virtual CustomFieldType CustomFieldType { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public IQueryable<ServiceTypeCustomField> GetServiceTypeCustomFields()
        {
            return _serviceTypeCustomFieldRepository.Get();
        }

        public ServiceTypeCustomField Find(int? key)
        {
            return _serviceTypeCustomFieldRepository.Find(key);
        }

        public int Create(ServiceTypeCustomField serviceTypeCustomField)
        {
            EnforceBusinessRules(serviceTypeCustomField);
            return _serviceTypeCustomFieldRepository.Create(serviceTypeCustomField);
        }

        public void Patch(int? serviceTypeCustomFieldID, Delta<ServiceTypeCustomField> delta)
        {
            var currentServiceTypeCustomField = Find(serviceTypeCustomFieldID);

            if (currentServiceTypeCustomField != null)
            {
                delta.Patch(currentServiceTypeCustomField);
                Validate(currentServiceTypeCustomField);
                EnforceBusinessRules(currentServiceTypeCustomField);
                _serviceTypeCustomFieldRepository.SavePatch();
            }
            else
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeCustomField.NotFound());
            }
        }

        public void Delete(int? key)
        {
            ServiceTypeCustomField currentCustomField = _serviceTypeCustomFieldRepository.Find(key);
            if (currentCustomField == null)
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeCustomField.NotFound());
            }

            _serviceTypeCustomFieldRepository.Delete(currentCustomField);
        }

        private void EnforceBusinessRules(ServiceTypeCustomField serviceTypeCustomField)
        {
            bool inputSequenceExists = _serviceTypeCustomFieldRepository.InputSequenceExists(serviceTypeCustomField);
            if (inputSequenceExists)
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeCustomField.InvalidInputSequence());
            }
            //custom field is select box
            if (serviceTypeCustomField.CustomFieldTypeID >= 100)
            {
                serviceTypeCustomField.CustomFieldDataTypeID = 8;//no data type validation
                serviceTypeCustomField.TextAlignment = "left";
            }
            //custom fields is radio button group
            if (serviceTypeCustomField.CustomFieldTypeID == 2 || serviceTypeCustomField.CustomFieldTypeID == 3)
            {
                serviceTypeCustomField.CustomFieldDataTypeID = 8;//no data type validation
                serviceTypeCustomField.TextAlignment = "left";
                serviceTypeCustomField.PlaceholderText = null;//no placeholder text required
            }
            //custom field type is data
            if (serviceTypeCustomField.CustomFieldTypeID == 4)
            {
                serviceTypeCustomField.CustomFieldDataTypeID = 8;//no data type validation
            }
        }

        private void Validate(ServiceTypeCustomField serviceTypeCustomField)
        {
            //if (updatedCase.Year > DateTime.Now.Year) throw new LegalException(ErrorMessages.Case.InvalidYear(updatedCase.Year));
        }
    }
}

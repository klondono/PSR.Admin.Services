namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using PublicServiceRequest.Admin.BLL.ErrorModel;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.OData;

    public partial class RequestActionTypeCustomFieldBLL : BaseModelBLL
    {
        private readonly IRequestActionTypeCustomFieldsRepository _requestActionTypeCustomFieldRepository;
        public RequestActionTypeCustomFieldBLL(IRequestActionTypeCustomFieldsRepository requestActionTypeCustomFieldsRepository)
        {
            if (requestActionTypeCustomFieldsRepository != null)
            {
                _requestActionTypeCustomFieldRepository = requestActionTypeCustomFieldsRepository;
            }
            else
            {
                throw new ArgumentNullException("IRequestActionTypeCustomFieldsRepository is null.");
            }
        }
        public int RequestActionTypeCustomFieldID { get; set; }

        public int? RequestActionTypeID { get; set; }

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

        public bool? DisplayFieldValueInCommentsFlag { get; set; }

        public virtual CustomFieldDataType CustomFieldDataType { get; set; }

        public virtual CustomFieldType CustomFieldType { get; set; }

        public virtual RequestActionType RequestActionType { get; set; }

        public IQueryable<RequestActionTypeCustomField> GetRequestActionTypeCustomFields()
        {
            return _requestActionTypeCustomFieldRepository.Get();
        }

        public RequestActionTypeCustomField Find(int? key)
        {
            return _requestActionTypeCustomFieldRepository.Find(key);
        }

        public int Create(RequestActionTypeCustomField actionTypeCustomField)
        {
            EnforceBusinessRules(actionTypeCustomField);
            return _requestActionTypeCustomFieldRepository.Create(actionTypeCustomField);
        }

        public void Patch(int? actionTypeCustomFieldID, Delta<RequestActionTypeCustomField> delta)
        {
            var currentCustomField = Find(actionTypeCustomFieldID);

            if (currentCustomField != null)
            {
                delta.Patch(currentCustomField);
                Validate(currentCustomField);
                EnforceBusinessRules(currentCustomField);
                _requestActionTypeCustomFieldRepository.SavePatch();
            }
            else
            {
                throw new PSRAdminException(ErrorMessages.ActionTypeCustomField.NotFound());
            }
        }

        public void Delete(int? key)
        {
            RequestActionTypeCustomField currentCustomField = _requestActionTypeCustomFieldRepository.Find(key);
            if (currentCustomField == null)
            {
                throw new PSRAdminException(ErrorMessages.ActionTypeCustomField.NotFound());
            }

            _requestActionTypeCustomFieldRepository.Delete(currentCustomField);
        }

        private void EnforceBusinessRules(RequestActionTypeCustomField actionTypeCustomField)
        {
            bool inputSequenceExists = _requestActionTypeCustomFieldRepository.InputSequenceExists(actionTypeCustomField);
            if (inputSequenceExists)
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeCustomField.InvalidInputSequence());
            }
            //custom field is select box
            if (actionTypeCustomField.CustomFieldTypeID >= 100)
            {
                actionTypeCustomField.CustomFieldDataTypeID = 8;//no data type validation
                actionTypeCustomField.TextAlignment = "left";
            }
            //custom fields is radio button group
            if (actionTypeCustomField.CustomFieldTypeID == 2 || actionTypeCustomField.CustomFieldTypeID == 3)
            {
                actionTypeCustomField.CustomFieldDataTypeID = 8;//no data type validation
                actionTypeCustomField.TextAlignment = "left";
                actionTypeCustomField.PlaceholderText = null;//no placeholder text required
                actionTypeCustomField.DisplayFieldValueInCommentsFlag = false;
            }
            //custom field type is data
            if (actionTypeCustomField.CustomFieldTypeID == 4)
            {
                actionTypeCustomField.CustomFieldDataTypeID = 8;//no data type validation
                actionTypeCustomField.DisplayFieldValueInCommentsFlag = false;
            }
        }

        private void Validate(RequestActionTypeCustomField requestActionTypeCustomField)
        {
            //if (updatedCase.Year > DateTime.Now.Year) throw new LegalException(ErrorMessages.Case.InvalidYear(updatedCase.Year));
        }


    }
}

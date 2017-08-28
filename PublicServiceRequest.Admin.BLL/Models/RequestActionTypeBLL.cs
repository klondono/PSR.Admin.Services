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

    public partial class RequestActionTypeBLL : BaseModelBLL
    {
        private readonly IRequestActionTypesRepository _requestActionTypeRepository;
        public RequestActionTypeBLL(IRequestActionTypesRepository requestActionTypesRepository)
        {
            if (requestActionTypesRepository != null)
            {
                _requestActionTypeRepository = requestActionTypesRepository;
            }
            else
            {
                throw new ArgumentNullException("IRequestActionTypesRepository is null.");
            }
        }

        public int RequestActionTypeID { get; set; }

        [StringLength(50)]
        public string RequestActionTypeName { get; set; }

        [StringLength(255)]
        public string RequestActionTypeDescription { get; set; }

        [StringLength(7)]
        public string BackgroundColor { get; set; }

        [StringLength(7)]
        public string TextColor { get; set; }

        public bool ChangeRequestStatusFlag { get; set; }

        public bool ReassignRequestFlag { get; set; }

        public bool AllowReplicationFlag { get; set; }

        public bool AllowUpdateOfServiceTypeFlag { get; set; }

        public bool AllowUpdateOfRequestFolioFlag { get; set; }

        public bool ByPassClientSideValidationFlag { get; set; }

        public bool DisplayFlag { get; set; }

        public bool UploadDocumentFlag { get; set; }

        public bool SystemReservedFlag { get; set; }

        public virtual ICollection<RequestActionTypeCustomField> RequestActionTypeCustomFields { get; set; }

        public virtual ICollection<ServiceTypeRequestActionTypeLink> ServiceTypeRequestActionTypeLinks { get; set; }

        public IQueryable<RequestActionType> GetRequestActionTypes()
        {
            return _requestActionTypeRepository.Get();
        }

        public RequestActionType Find(int? key)
        {
            return _requestActionTypeRepository.Find(key);
        }

        public int Create(RequestActionType requestActionType)
        {
            EnforceBusinessRules(requestActionType);
            return _requestActionTypeRepository.Create(requestActionType);
        }

        public void Patch(int? requestActionTypeID, Delta<RequestActionType> delta)
        {
            var currentRequestActionType = Find(requestActionTypeID);

            if (currentRequestActionType != null)
            {
                delta.Patch(currentRequestActionType);
                Validate(currentRequestActionType);
                EnforceBusinessRules(currentRequestActionType);
                _requestActionTypeRepository.SavePatch();
            }
            else
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeCustomField.NotFound());
            }
        }

        public void Delete(int? key)
        {
            RequestActionType currentCustomField = _requestActionTypeRepository.Find(key);
            if (currentCustomField == null)
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeCustomField.NotFound());
            }

            _requestActionTypeRepository.Delete(currentCustomField);
        }

        private void EnforceBusinessRules(RequestActionType requestActionType)
        {
            //bool inputSequenceExists = _requestActionTypeRepository.InputSequenceExists(serviceTypeCustomField);
            //if (inputSequenceExists)
            //{
            //    throw new PSRAdminException(ErrorMessages.ServiceTypeCustomField.InvalidInputSequence());
            //}
            ////custom field is select box
            //if (serviceTypeCustomField.CustomFieldTypeID >= 100)
            //{
            //    serviceTypeCustomField.CustomFieldDataTypeID = 8;//no data type validation
            //    serviceTypeCustomField.TextAlignment = "left";
            //}
            ////custom fields is radio button group
            //if (serviceTypeCustomField.CustomFieldTypeID == 2 || serviceTypeCustomField.CustomFieldTypeID == 3)
            //{
            //    serviceTypeCustomField.CustomFieldDataTypeID = 8;//no data type validation
            //    serviceTypeCustomField.TextAlignment = "left";
            //    serviceTypeCustomField.PlaceholderText = null;//no placeholder text required
            //}
            ////custom field type is data
            //if (serviceTypeCustomField.CustomFieldTypeID == 4)
            //{
            //    serviceTypeCustomField.CustomFieldDataTypeID = 8;//no data type validation
            //}
        }

        private void Validate(RequestActionType requestActionType)
        {
            //if (updatedCase.Year > DateTime.Now.Year) throw new LegalException(ErrorMessages.Case.InvalidYear(updatedCase.Year));
        }
    }
}

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

    public partial class ServiceTypeRelationshipDefinitionBLL : BaseModelBLL
    {
        private readonly IServiceTypeRelationshipDefinitionsRepository _serviceTypeRelationshipDefinitionRepository;
        public ServiceTypeRelationshipDefinitionBLL(IServiceTypeRelationshipDefinitionsRepository serviceTypeRelationshipDefinitionsRepository)
        {
            if (serviceTypeRelationshipDefinitionsRepository != null)
            {
                _serviceTypeRelationshipDefinitionRepository = serviceTypeRelationshipDefinitionsRepository;
            }
            else
            {
                throw new ArgumentNullException("IServiceTypeRelationshipDefinitionsRepository is null.");
            }
        }
        public int ServiceTypeRelationshipDefinitionID { get; set; }

        public int? ServiceTypeParentID { get; set; }

        public int? ServiceTypeChildID { get; set; }

        public int? ServiceTypeChildStartTriggerID { get; set; }

        public int? ServiceTypeChildStartDelay { get; set; }

        public int? ServiceTypeChildDuration { get; set; }

        public bool? ServiceTypeChildRequiredFlag { get; set; }

        public bool? ServiceTypeChildCheckedByDefaultFlag { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual ServiceType ServiceType1 { get; set; }

        public virtual ServiceTypeChildStartTrigger ServiceTypeChildStartTrigger { get; set; }

        public IQueryable<ServiceTypeRelationshipDefinition> GetServiceTypeRelationshipDefinitions()
        {
            return _serviceTypeRelationshipDefinitionRepository.Get();
        }

        public ServiceTypeRelationshipDefinition Find(int? key)
        {
            return _serviceTypeRelationshipDefinitionRepository.Find(key);
        }

        public ServiceTypeRelationshipDefinition Create(ServiceTypeRelationshipDefinition serviceTypeCustomField)
        {
            EnforceBusinessRules(serviceTypeCustomField);
            return _serviceTypeRelationshipDefinitionRepository.Create(serviceTypeCustomField);
        }

        public ServiceTypeRelationshipDefinition Patch(int? serviceTypeRelationshipDefinitionID, Delta<ServiceTypeRelationshipDefinition> delta)
        {
            var currentserviceTypeRelationship = Find(serviceTypeRelationshipDefinitionID);
            //make copy of original object in case we need to rollback change due to circular reference
            var copyCurrentServiceTypeRelationship = new ServiceTypeRelationshipDefinition()
            {
                ServiceTypeRelationshipDefinitionID = currentserviceTypeRelationship.ServiceTypeRelationshipDefinitionID,
                ServiceTypeParentID = currentserviceTypeRelationship.ServiceTypeParentID,
                ServiceTypeChildID = currentserviceTypeRelationship.ServiceTypeChildID,
                ServiceTypeChildStartTriggerID = currentserviceTypeRelationship.ServiceTypeChildStartTriggerID,
                ServiceTypeChildStartDelay = currentserviceTypeRelationship.ServiceTypeChildStartDelay,
                ServiceTypeChildDuration = currentserviceTypeRelationship.ServiceTypeChildDuration,
                ServiceTypeChildRequiredFlag = currentserviceTypeRelationship.ServiceTypeChildRequiredFlag,
                ServiceTypeChildCheckedByDefaultFlag = currentserviceTypeRelationship.ServiceTypeChildCheckedByDefaultFlag,
                AdmIsActive = currentserviceTypeRelationship.AdmIsActive,
                AdmUserAdded = currentserviceTypeRelationship.AdmUserAdded,
                AdmUserAddedFullName = currentserviceTypeRelationship.AdmUserAddedFullName,
                AdmDateAdded = currentserviceTypeRelationship.AdmDateAdded,
                AdmUserModified = currentserviceTypeRelationship.AdmUserModified,
                AdmUserModifiedFullName = currentserviceTypeRelationship.AdmUserModifiedFullName,
                AdmDateModified = currentserviceTypeRelationship.AdmDateModified,
                AdmUserAddedDomainName = currentserviceTypeRelationship.AdmUserAddedDomainName,
                AdmUserModifiedDomainName = currentserviceTypeRelationship.AdmUserModifiedDomainName
            };

            if (currentserviceTypeRelationship != null)
            {
                delta.Patch(currentserviceTypeRelationship);
                Validate(currentserviceTypeRelationship);
                EnforceBusinessRules(currentserviceTypeRelationship);
                _serviceTypeRelationshipDefinitionRepository.SavePatch(copyCurrentServiceTypeRelationship);
                return new ServiceTypeRelationshipDefinition();
            }
            else
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeCustomField.NotFound());
            }
        }

        public void Delete(ServiceTypeRelationshipDefinitionDeletionModel deletionModel)
        {
            ServiceTypeRelationshipDefinition currentserviceTypeRelationship = _serviceTypeRelationshipDefinitionRepository.Find(deletionModel.ServiceTypeRelationshipDefinitionID);
            


            if (currentserviceTypeRelationship == null)
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeCustomField.NotFound());
            }

            switch (deletionModel.DeletionTypeCode)
            {
                case 0:
                    _serviceTypeRelationshipDefinitionRepository.DeleteAndConnectDecendantsToRoot(currentserviceTypeRelationship);
                    break;
                case 1:
                    _serviceTypeRelationshipDefinitionRepository.DeleteWithDecendants(currentserviceTypeRelationship);
                    break;
                default:
                    _serviceTypeRelationshipDefinitionRepository.DeleteAndConnectDecendantsToGrandParent(currentserviceTypeRelationship);
                    break;
            }
        }

        private void EnforceBusinessRules(ServiceTypeRelationshipDefinition serviceTypeRelationship)
        {
            bool relationshipExists = _serviceTypeRelationshipDefinitionRepository.RelationshipExists(serviceTypeRelationship);
            if (relationshipExists)
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeRelationshipDefinition.RelationshipExists());
            }

            if(serviceTypeRelationship.ServiceTypeChildID == serviceTypeRelationship.ServiceTypeParentID)
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeRelationshipDefinition.SelfReference());
            }
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

        private void Validate(ServiceTypeRelationshipDefinition serviceTypeRelationship)
        {
            //if (updatedCase.Year > DateTime.Now.Year) throw new LegalException(ErrorMessages.Case.InvalidYear(updatedCase.Year));
        }
    }

    public class ServiceTypeRelationshipDefinitionDeletionModel
    {
        [Key]
        public int ServiceTypeRelationshipDefinitionID { get; set; }
        public int DeletionTypeCode { get; set; }

    }
}

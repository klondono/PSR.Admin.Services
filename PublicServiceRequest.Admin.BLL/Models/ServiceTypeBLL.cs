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

    public partial class ServiceTypeBLL : BaseModelBLL
    {
        private readonly IServiceTypesRepository _serviceTypesRepository;
        public ServiceTypeBLL(IServiceTypesRepository serviceTypesRepository)
        {
            if (serviceTypesRepository != null)
            {
                _serviceTypesRepository = serviceTypesRepository;
            }
            else
            {
                throw new ArgumentNullException("IServiceTypesRepository is null.");
            }
        }
        public int ServiceTypeID { get; set; }

        public Guid? ServiceTypeOwnerGroupID { get; set; }

        public int? DefaultRequestStatusID { get; set; }

        public int? EscalationExpectedStatusID { get; set; }

        public int ServiceTypeNumber { get; set; }

        public Guid? ServiceTypeOwnerGroupOverrideID { get; set; }

        [StringLength(4)]
        public string ServiceTypeOwnerGroupOverrideMonthDayFrom { get; set; }

        [StringLength(4)]
        public string ServiceTypeOwnerGroupOverrideMonthDayTo { get; set; }

        [StringLength(50)]
        public string ServiceTypeName { get; set; }

        [StringLength(255)]
        public string ServiceTypeDescription { get; set; }

        public int? ServiceTypeDefaultDuration { get; set; }

        public bool? ServiceTypeAssigneeDependantOnPropertyFlag { get; set; }

        public bool? ServiceTypeIncludePropertyInfoFlag { get; set; }

        public bool? ServiceTypeIncludeFirstActionCommentFlag { get; set; }

        public bool? ServiceTypeShowAsStandaloneServiceFlag { get; set; }

        public bool SelectableOnServiceTypeUpdateFlag { get; set; }

        public bool? ServiceTypeParentClosesWhenChildrenClosedFlag { get; set; }

        public bool ServiceTypeConcurrentCreationOfChildrenFlag { get; set; }

        [StringLength(1000)]
        public string ServiceTypeAvailableToActiveDirectoryGroupName { get; set; }

        public bool ServiceTypeAssigneeDependantOnOriginFlag { get; set; }

        public int? ServiceTypeDependantOriginID { get; set; }

        public Guid? ServiceTypeOwnerGroupOverrideOriginBased { get; set; }

        public int? DefaultRequestFolioTypeID { get; set; }

        public bool ForceRequestFolioType { get; set; }

        public IQueryable<ServiceType> GetServiceTypes()
        {
            return _serviceTypesRepository.Get();
        }

        public ServiceType Find(int? key)
        {
            return _serviceTypesRepository.Find(key);
        }

        public int Create(ServiceType serviceType)
        {
            return _serviceTypesRepository.Create(serviceType);
        }

        public int Clone(int serviceTypeID)
        {
            return _serviceTypesRepository.Clone(serviceTypeID);
        }

        public void Patch(int? serviceTypeID, Delta<ServiceType> delta)
        {
            var currentServiceType = Find(serviceTypeID);

            if (currentServiceType != null)
            {
                delta.Patch(currentServiceType);
                Validate(currentServiceType);
                EnforceBusinessRules(currentServiceType);
                _serviceTypesRepository.SavePatch();
            }
            else
            {
                throw new PSRAdminException(ErrorMessages.ServiceType.NotFound());
            }
        }

        private void EnforceBusinessRules(ServiceType serviceType)
        {
            if (serviceType.ServiceTypeIncludePropertyInfoFlag == false)
            {
                serviceType.DefaultRequestFolioTypeID = null;
                serviceType.ForceRequestFolioType = false;
                serviceType.ServiceTypeAssigneeDependantOnPropertyFlag = false;
            }

            if (serviceType.ServiceTypeAssigneeDependantOnOriginFlag == false)
            {
                serviceType.ServiceTypeOwnerGroupOverrideOriginBased = null;
                serviceType.ServiceTypeDependantOriginID = null;
            }

            if (!_serviceTypesRepository.IsParent(serviceType.ServiceTypeID))
            {
                serviceType.ServiceTypeParentClosesWhenChildrenClosedFlag = false;
                serviceType.ServiceTypeConcurrentCreationOfChildrenFlag = false;
            }

            if (serviceType.ServiceTypeShowAsStandaloneServiceFlag == true && !_serviceTypesRepository.BusinessAreaIsVisibleOnPSRCreation(serviceType.ServiceTypeOwnerGroupID))
            {
                throw new PSRAdminException(ErrorMessages.ServiceType.InvalidOwnerGroupSelection());
            }
        }

        private void Validate(ServiceType serviceType)
        {
            //if (updatedCase.Year > DateTime.Now.Year) throw new LegalException(ErrorMessages.Case.InvalidYear(updatedCase.Year));
        }
    }
}

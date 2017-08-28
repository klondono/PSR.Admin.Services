namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using ErrorModel;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class ServiceTypeRequestActionTypeLinkBLL : BaseModelBLL
    {
        private readonly IServiceTypeRequestActionTypeLinksRepository _serviceTypeRequestActionTypeLinkRepository;
        public ServiceTypeRequestActionTypeLinkBLL(IServiceTypeRequestActionTypeLinksRepository serviceTypeRequestActionTypeLinksRepository)
        {
            if (serviceTypeRequestActionTypeLinksRepository != null)
            {
                _serviceTypeRequestActionTypeLinkRepository = serviceTypeRequestActionTypeLinksRepository;
            }
            else
            {
                throw new ArgumentNullException("IServiceTypeRequestActionTypeLinksRepository is null.");
            }
        }
        public int ServiceTypeRequestActionTypeLinkID { get; set; }

        public int ServiceTypeID { get; set; }

        public int RequestActionTypeID { get; set; }

        [StringLength(1000)]
        public string AddActionActiveDirectoryGroupName { get; set; }

        [StringLength(1000)]
        public string UpdateActionActiveDirectoryGroupName { get; set; }

        [StringLength(1000)]
        public string DeleteActionActiveDirectoryGroupName { get; set; }

        public int? MaximumAllowedOcurrence { get; set; }

        public int? ListSequence { get; set; }

        public int? RequestWorkspaceDisplayCode { get; set; }

        [StringLength(1000)]
        public string PrecedenceConstraintRequestActionTypeIDValue { get; set; }

        public bool? PrecedenceConstraintLogicalOperatorIsORFlag { get; set; }

        public virtual RequestActionType RequestActionType { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public IQueryable<ServiceTypeRequestActionTypeLink> GetServiceTypeRequestActionTypeLinks()
        {
            return _serviceTypeRequestActionTypeLinkRepository.Get();
        }

        public IQueryable<ServiceTypeRequestActionTypeLink> Find(int? key)
        {
            return _serviceTypeRequestActionTypeLinkRepository.Find(key);
        }

        public IQueryable<ServiceTypeRequestActionTypeLink> UpdateActionTypesForServiceType(ServiceTypeActionTypeLinkContainerModel updateActionTypeLinkContainer)
        {
            Validate(updateActionTypeLinkContainer);
            EnforceBusinessRules(updateActionTypeLinkContainer);

            return _serviceTypeRequestActionTypeLinkRepository.AddOrUpdate(updateActionTypeLinkContainer.ServiceTypeID, updateActionTypeLinkContainer.ServiceTypeActionTypeLinkUpdateModel, updateActionTypeLinkContainer.DeletedActionTypeLinkIDs);
        }

        private void EnforceBusinessRules(ServiceTypeActionTypeLinkContainerModel updateActionTypeLinkContainer)
        {
            //var precedenceConstraintActionTypeIDs = updateActionTypeLinkContainer.ServiceTypeActionTypeLinkUpdateModel.

            //if (serviceType.ServiceTypeShowAsStandaloneServiceFlag == true && !_serviceTypesRepository.BusinessAreaIsVisibleOnPSRCreation(serviceType.ServiceTypeOwnerGroupID))
            //{
            //    throw new PSRAdminException(ErrorMessages.ServiceType.InvalidOwnerGroupSelection());
            //}
        }

        private void Validate(ServiceTypeActionTypeLinkContainerModel updateActionTypeLinkContainer)
        {
            //if (updatedCase.Year > DateTime.Now.Year) throw new LegalException(ErrorMessages.Case.InvalidYear(updatedCase.Year));
        }
    }

    public class ServiceTypeActionTypeLinkContainerModel
    {
        [Key]
        public int ServiceTypeID { get; set; }
        public List<int> DeletedActionTypeLinkIDs { get; set; }
        public List<ServiceTypeActionTypeLinkUpdateModel> ServiceTypeActionTypeLinkUpdateModel { get; set; }

    }

    public class ServiceTypeActionTypeLinkUpdateModel
    {
        public ServiceTypeActionTypeLinkUpdateModel()
        {
            PrecedenceConstraintLogicalOperatorIsORFlag = null;
        }
        [Key]
        public int ServiceTypeRequestActionTypeLinkID { get; set; }
        public int ServiceTypeID { get; set; }
        public int RequestActionTypeID { get; set; }
        [StringLength(1000)]
        public string AddActionActiveDirectoryGroupName { get; set; }
        [StringLength(1000)]
        public string UpdateActionActiveDirectoryGroupName { get; set; }
        [StringLength(1000)]
        public string DeleteActionActiveDirectoryGroupName { get; set; }
        public int? MaximumAllowedOcurrence { get; set; }
        public int? ListSequence { get; set; }
        public int? RequestWorkspaceDisplayCode { get; set; }
        [StringLength(1000)]
        public string PrecedenceConstraintRequestActionTypeIDValue { get; set; }
        public bool? PrecedenceConstraintLogicalOperatorIsORFlag { get; set; }
    }
}

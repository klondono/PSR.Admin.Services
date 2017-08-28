namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class ServiceTypeOwnerGroupBLL: BaseModelBLL
    {
        private readonly IServiceTypeOwnerGroupsRepository _serviceTypeOwnerGroupsRepository;
        public ServiceTypeOwnerGroupBLL(IServiceTypeOwnerGroupsRepository serviceTypeOwnerGroupsRepository)
        {
            if (serviceTypeOwnerGroupsRepository != null)
            {
                _serviceTypeOwnerGroupsRepository = serviceTypeOwnerGroupsRepository;
            }
            else
            {
                throw new ArgumentNullException("IServiceTypeOwnerGroupsRepository is null.");
            }
        }

        public Guid ServiceTypeOwnerGroupID { get; set; }

        public int? ServiceTypeOwnerGroupLocationID { get; set; }

        [Required]
        [StringLength(100)]
        public string ServiceTypeOwnerGroupName { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupDescription { get; set; }

        [StringLength(1000)]
        public string ServiceTypeOwnerAvailableToActiveDirectoryGroupName { get; set; }

        [StringLength(1000)]
        public string ServiceTypeOwnerActiveDirectoryGroupName { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupMainEmail { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupNotificationEmail { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupEscalationEmail { get; set; }

        [StringLength(25)]
        public string ServiceTypeOwnerGroupPhoneNo { get; set; }

        public int? ServiceTypeOwnerGroupDistrictNo { get; set; }

        public bool? SelectableOnRequestCreationFlag { get; set; }

        public bool? SelectableOnRequestReassignmentFlag { get; set; }

        public IQueryable<ServiceTypeOwnerGroup> GetServiceTypeOwnerGroups()
        {
            return _serviceTypeOwnerGroupsRepository.Get();
        }

        public IQueryable<ServiceTypeOwnerGroup> Find(Guid? key)
        {
            return _serviceTypeOwnerGroupsRepository.Find(key);
        }
    }
}

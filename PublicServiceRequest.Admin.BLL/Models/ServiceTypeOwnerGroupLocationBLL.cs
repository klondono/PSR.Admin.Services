namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class ServiceTypeOwnerGroupLocationBLL : BaseModelBLL
    {
        private readonly IServiceTypeOwnerGroupLocationsRepository _serviceTypeOwnerGroupLocationRepository;
        public ServiceTypeOwnerGroupLocationBLL(IServiceTypeOwnerGroupLocationsRepository serviceTypeOwnerGroupLocationsRepository)
        {
            if (serviceTypeOwnerGroupLocationsRepository != null)
            {
                _serviceTypeOwnerGroupLocationRepository = serviceTypeOwnerGroupLocationsRepository;
            }
            else
            {
                throw new ArgumentNullException("IServiceTypeOwnerGroupLocationsRepository is null.");
            }
        }

        public int ServiceTypeOwnerGroupLocationID { get; set; }

        [StringLength(50)]
        public string ServiceTypeOwnerGroupLocationName { get; set; }

        public virtual ICollection<ServiceTypeOwnerGroup> ServiceTypeOwnerGroups { get; set; }

        public IQueryable<ServiceTypeOwnerGroupLocation> GetServiceTypeOwnerGroupLocations()
        {
            return _serviceTypeOwnerGroupLocationRepository.Get();
        }

        public IQueryable<ServiceTypeOwnerGroupLocation> Find(int? key)
        {
            return _serviceTypeOwnerGroupLocationRepository.Find(key);
        }
    }
}

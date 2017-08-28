namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class ServiceTypeSearchKeywordLinkBLL : BaseModelBLL
    {
        private readonly IServiceTypeSearchKeywordLinksRepository _serviceTypeSearchKeywordLinksRepository;
        public ServiceTypeSearchKeywordLinkBLL(IServiceTypeSearchKeywordLinksRepository serviceTypeSearchKeywordLinksRepository)
        {
            if (serviceTypeSearchKeywordLinksRepository != null)
            {
                _serviceTypeSearchKeywordLinksRepository = serviceTypeSearchKeywordLinksRepository;
            }
            else
            {
                throw new ArgumentNullException("IServiceTypeSearchKeywordLinksRepository is null.");
            }
        }

        public int ServiceTypeSearchKeywordLinkID { get; set; }

        public int? ServiceTypeID { get; set; }

        public int? ServiceTypeSearchKeywordID { get; set; }

        public IQueryable<ServiceTypeSearchKeywordLink> GetServiceTypeSearchKeywordLinks()
        {
            return _serviceTypeSearchKeywordLinksRepository.Get();
        }

        public IQueryable<ServiceTypeSearchKeywordLink> Find(int? key)
        {
            return _serviceTypeSearchKeywordLinksRepository.Find(key);
        }
    }
}

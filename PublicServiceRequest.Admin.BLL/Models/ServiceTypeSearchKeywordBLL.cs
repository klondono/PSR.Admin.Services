namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using ErrorModel;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class ServiceTypeSearchKeywordBLL: BaseModelBLL
    {
        private readonly IServiceTypeSearchKeywordsRepository _serviceTypeSearchKeywordsRepository;
        public ServiceTypeSearchKeywordBLL(IServiceTypeSearchKeywordsRepository serviceTypeSearchKeywordsRepository)
        {
            if (serviceTypeSearchKeywordsRepository != null)
            {
                _serviceTypeSearchKeywordsRepository = serviceTypeSearchKeywordsRepository;
            }
            else
            {
                throw new ArgumentNullException("IServiceTypeSearchKeywordsRepository is null.");
            }
        }

        public int ServiceTypeSearchKeywordID { get; set; }

        [StringLength(50)]
        public string ServiceTypeSearchKeywordName { get; set; }

        public IQueryable<ServiceTypeSearchKeyword> GetServiceTypeSearchKeywords()
        {
            return _serviceTypeSearchKeywordsRepository.Get();
        }

        public IQueryable<ServiceTypeSearchKeyword> Find(int? key)
        {
            return _serviceTypeSearchKeywordsRepository.Find(key);
        }

        public List<ServiceTypeSearchKeywordLinkModel> UpdateKeywordsForServiceType(ServiceTypeSearchKeywordContainerModel updateKeywordContainer)
        {
            Validate(updateKeywordContainer);
            EnforceBusinessRules(updateKeywordContainer);

            var keywordIdsToBeDeleted = string.Join(",", updateKeywordContainer.DeletedSearchTermIDs);

            try
            {
                return _serviceTypeSearchKeywordsRepository.AddOrUpdate(updateKeywordContainer.ServiceTypeID, updateKeywordContainer.ServiceTypeSearchKeywordUpdateModel, keywordIdsToBeDeleted);
            }
            catch (PSRAdminException ex)
            {
                throw new Exception(ErrorMessages.ServiceTypeSearchKeyword.GeneralException(ex.ToString()));
            }
        }

        private void EnforceBusinessRules(ServiceTypeSearchKeywordContainerModel updateKeywordContainer)
        {
            
        }

        private void Validate(ServiceTypeSearchKeywordContainerModel updateKeywordContainer)
        {
            //if (updatedCase.Year > DateTime.Now.Year) throw new LegalException(ErrorMessages.Case.InvalidYear(updatedCase.Year));
        }
    }

    public class ServiceTypeSearchKeywordContainerModel
    {
        [Key]
        public int ServiceTypeID { get; set; }
        public List<int> DeletedSearchTermIDs { get; set; }
        public List<ServiceTypeSearchKeywordUpdateModel> ServiceTypeSearchKeywordUpdateModel { get; set; }

    }

    public class ServiceTypeSearchKeywordUpdateModel
    {
        [Key]
        public int ServiceTypeSearchKeywordID { get; set; }
        public int ServiceTypeSearchKeywordLinkID { get; set; }
        public string ServiceTypeSearchKeywordName { get; set; }
    }

    public class ServiceTypeSearchKeywordModel
    {
        [Key]
        public int ServiceTypeSearchKeywordID { get; set; }

        [StringLength(50)]
        public string ServiceTypeSearchKeywordName { get; set; }
    }

    public class ServiceTypeSearchKeywordLinkModel
    {
        [Key]
        public int ServiceTypeSearchKeywordLinkID { get; set; }

        public ServiceTypeSearchKeywordModel ServiceTypeSearchKeyword { get; set; }
    }
}

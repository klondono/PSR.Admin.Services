namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class RequestTaxpayerPreferredLanguageBLL : BaseModelBLL
    {
        private readonly IRequestTaxpayerPreferredLanguagesRepository _requestTaxpayerPreferredLanguageRepository;
        public RequestTaxpayerPreferredLanguageBLL(IRequestTaxpayerPreferredLanguagesRepository requestTaxpayerPreferredLanguagesRepository)
        {
            if (requestTaxpayerPreferredLanguagesRepository != null)
            {
                _requestTaxpayerPreferredLanguageRepository = requestTaxpayerPreferredLanguagesRepository;
            }
            else
            {
                throw new ArgumentNullException("IRequestTaxpayerPreferredLanguagesRepository is null.");
            }
        }
        public int RequestTaxpayerPreferredLanguageID { get; set; }

        [StringLength(50)]
        public string RequestTaxpayerPreferredLanguageName { get; set; }

        [StringLength(255)]
        public string RequestTaxpayerPreferredLanguageDescription { get; set; }
        public IQueryable<RequestTaxpayerPreferredLanguage> GetRequestTaxpayerPreferredLanguages()
        {
            return _requestTaxpayerPreferredLanguageRepository.Get();
        }

        public IQueryable<RequestTaxpayerPreferredLanguage> Find(int? key)
        {
            return _requestTaxpayerPreferredLanguageRepository.Find(key);
        }

    }
}

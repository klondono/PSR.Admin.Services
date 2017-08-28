using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PublicServiceRequest.Admin.DAL.Models;
using PublicServiceRequest.Admin.BLL.Repositories.Interface;
using PublicServiceRequest.Admin.Common.Models;

namespace PublicServiceRequest.Admin.DAL.Repositories.Implementation
{
    public class RequestTaxpayerPreferredLanguagesRepository : IRequestTaxpayerPreferredLanguagesRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<RequestTaxpayerPreferredLanguage> Get()
        {
            return db.RequestTaxpayerPreferredLanguages;
        }

        public IQueryable<RequestTaxpayerPreferredLanguage> Find(int? key)
        {
            return db.RequestTaxpayerPreferredLanguages.Where(requestTaxpayerPreferredLanguage => requestTaxpayerPreferredLanguage.RequestTaxpayerPreferredLanguageID == key);
        }

    }
}

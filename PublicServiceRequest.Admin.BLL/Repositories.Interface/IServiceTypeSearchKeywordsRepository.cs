using PublicServiceRequest.Admin.BLL.Models;
using PublicServiceRequest.Admin.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServiceRequest.Admin.BLL.Repositories.Interface
{
    public interface IServiceTypeSearchKeywordsRepository
    {
        IQueryable<ServiceTypeSearchKeyword> Get();
        IQueryable<ServiceTypeSearchKeyword> Find(int? key);
        List<ServiceTypeSearchKeywordLinkModel> AddOrUpdate(int serviceTypeID, List<ServiceTypeSearchKeywordUpdateModel> keywordsToBeUpdated, string keywordIdsToBeDeleted);
    }
}

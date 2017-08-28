using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PublicServiceRequest.Admin.DAL.Models;
using PublicServiceRequest.Admin.BLL.Repositories.Interface;
using PublicServiceRequest.Admin.Common.Models;
using PublicServiceRequest.Admin.BLL.Models;
using PublicServiceRequest.Admin.BLL.ErrorModel;
using System.Data.Entity;

namespace PublicServiceRequest.Admin.DAL.Repositories.Implementation
{
    public class ServiceTypeSearchKeywordsRepository : IServiceTypeSearchKeywordsRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<ServiceTypeSearchKeyword> Get()
        {
            return db.ServiceTypeSearchKeywords;
        }

        public IQueryable<ServiceTypeSearchKeyword> Find(int? key)
        {
            return db.ServiceTypeSearchKeywords.Where(serviceTypeSearchKeyword => serviceTypeSearchKeyword.ServiceTypeSearchKeywordID == key);
        }

        public List<ServiceTypeSearchKeywordLinkModel> AddOrUpdate(int serviceTypeID, List<ServiceTypeSearchKeywordUpdateModel> keywordsToBeUpdated, string keywordIdsToBeDeleted)
        {
            try
            {
                if(!String.IsNullOrEmpty(keywordIdsToBeDeleted))
                {
                    //delete keyword from ServiceTypeSearchKeyword table AND ServiceTypeSearchKeywordLink table
                    string strDeleteQuery = "DELETE FROM [PSR].[ServiceTypeSearchKeywordLink] " +
                                            "WHERE ServiceTypeSearchKeywordID IN(SELECT ServiceTypeSearchKeywordID FROM [PSR].[ServiceTypeSearchKeyword] " +
                                            $"WHERE ServiceTypeSearchKeywordID IN ({keywordIdsToBeDeleted})) " +
                                            $"DELETE FROM [PSR].[ServiceTypeSearchKeyword] WHERE ServiceTypeSearchKeywordID IN({keywordIdsToBeDeleted})";

                    db.Database.ExecuteSqlCommand(strDeleteQuery);
                }

                foreach(var keyword in keywordsToBeUpdated)
                {
                    if(keyword.ServiceTypeSearchKeywordID == 0)
                    {
                        var newKeywordLink = new ServiceTypeSearchKeywordLink()
                        {
                            ServiceTypeID = serviceTypeID,
                            ServiceTypeSearchKeyword = new ServiceTypeSearchKeyword()
                            {
                                ServiceTypeSearchKeywordName = keyword.ServiceTypeSearchKeywordName
                            }
                        };

                        db.ServiceTypeSearchKeywordLinks.Add(newKeywordLink);
                    }
                    else if(keyword.ServiceTypeSearchKeywordID > 0)
                    {
                        var currentKeyword = Find(keyword.ServiceTypeSearchKeywordID).FirstOrDefault();
                        if (currentKeyword == null)
                        {
                            throw new PSRAdminException(ErrorMessages.ServiceTypeSearchKeyword.NotFound(keyword.ServiceTypeSearchKeywordID.ToString()));
                        }
                        else
                        {
                            if (currentKeyword.ServiceTypeSearchKeywordName != keyword.ServiceTypeSearchKeywordName)
                            {
                                currentKeyword.ServiceTypeSearchKeywordName = keyword.ServiceTypeSearchKeywordName;
                                db.Entry(currentKeyword).State = EntityState.Modified;
                            }
                        }
                    }
                }
                db.SaveChanges();

                return db.ServiceTypeSearchKeywordLinks
                    .Include(x => x.ServiceTypeSearchKeyword)
                    .Where(x => x.ServiceTypeID == serviceTypeID).Select(x => new ServiceTypeSearchKeywordLinkModel() {
                        ServiceTypeSearchKeywordLinkID = x.ServiceTypeSearchKeywordLinkID,
                        ServiceTypeSearchKeyword = new ServiceTypeSearchKeywordModel()
                        {
                            ServiceTypeSearchKeywordID = x.ServiceTypeSearchKeyword.ServiceTypeSearchKeywordID,
                            ServiceTypeSearchKeywordName = x.ServiceTypeSearchKeyword.ServiceTypeSearchKeywordName
                        }
                    }).ToList();
            }
            catch (PSRAdminException ex)
            {
                throw new PSRAdminException("Error in ServiceTypeSearchKeyword AddOrUpdate Method: " + ex.ToString());
            }
        }
    }
}

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
    public class ServiceTypeRequestActionTypeLinksRepository : IServiceTypeRequestActionTypeLinksRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<ServiceTypeRequestActionTypeLink> Get()
        {
            return db.ServiceTypeRequestActionTypeLinks;
        }

        public IQueryable<ServiceTypeRequestActionTypeLink> Find(int? key)
        {
            return db.ServiceTypeRequestActionTypeLinks.Where(serviceTypeRequestActionTypeLink => serviceTypeRequestActionTypeLink.ServiceTypeRequestActionTypeLinkID == key);
        }

        private void checkIfActionTypeInputIsValid(ServiceTypeActionTypeLinkUpdateModel actionTypeLink)
        {
        }

        private void checkIfActionTypeIsDuplicate(ServiceTypeActionTypeLinkUpdateModel actionTypeLink, List<ServiceTypeActionTypeLinkUpdateModel> actionTypeLinksToBeUpdated, int serviceTypeID)
        {
            var actionTypeAlreadyLinked = actionTypeLinksToBeUpdated.Where(x => x.ServiceTypeID == serviceTypeID &&
                x.RequestActionTypeID == actionTypeLink.RequestActionTypeID).Count();

            if (actionTypeAlreadyLinked > 1)
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeRequestActionTypeLink.DuplicateLink(actionTypeLink.RequestActionTypeID));
            }
        }

        private void checkIfPrecedenceConstraintValuesAreValid(ServiceTypeActionTypeLinkUpdateModel actionTypeLink, string requestActionTypeID, 
            List<ServiceTypeActionTypeLinkUpdateModel> actionTypeLinksToBeUpdated, string strActionTypeLinkIdsToBeDeleted, int serviceTypeID)
        {
            if (actionTypeLink.PrecedenceConstraintLogicalOperatorIsORFlag == null)
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeRequestActionTypeLink.PrecedenceRuleIsNull(actionTypeLink.RequestActionTypeID));
            }
            string[] arrRequestActionTypeIDs = actionTypeLink.PrecedenceConstraintRequestActionTypeIDValue.Split(',');
            //make sure action type does not contain action type id's in arrRequestActionTypeIDs that refer to itself
            if (arrRequestActionTypeIDs.Where(x => x == requestActionTypeID).Any())
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeRequestActionTypeLink.PrecedenceConstraintRefersToSelf(requestActionTypeID));
            }

            if(!String.IsNullOrWhiteSpace(strActionTypeLinkIdsToBeDeleted))
            {
                var strDeletedCountQuery = $"SELECT COUNT(*) FROM [PSR].[ServiceTypeRequestActionTypeLink] WHERE ServiceTypeRequestActionTypeLinkID IN ({strActionTypeLinkIdsToBeDeleted}) AND RequestActionTypeID IN " +
                $"(SELECT RequestActionTypeID FROM [PSR].[ServiceTypeRequestActionTypeLink] WHERE ServiceTypeID = {serviceTypeID} AND RequestActionTypeID IN ({actionTypeLink.PrecedenceConstraintRequestActionTypeIDValue}))";

                var actionTypeLinkWillBeDeleted = db.Database.SqlQuery<int>(strDeletedCountQuery).Any();
                if (actionTypeLinkWillBeDeleted)
                {
                    throw new PSRAdminException(ErrorMessages.ServiceTypeRequestActionTypeLink.PrecedenceConstraintWillBeDeleted());
                }
            }

            //Check whether precedence action type id's exist in action types that are linked to the current service type
            var lstRequestActionTypeIDs = arrRequestActionTypeIDs.ToList();
            lstRequestActionTypeIDs.ForEach(x => CheckIfPrecedenceActionTypeIDExistsForServiceType(x, actionTypeLinksToBeUpdated));
        }

        private void CheckIfPrecedenceActionTypeIDExistsForServiceType(string precedenceConstraintID, List<ServiceTypeActionTypeLinkUpdateModel> actionTypeLinksToBeUpdated)
        {
            if (!actionTypeLinksToBeUpdated.Where(x => x.RequestActionTypeID.ToString() == precedenceConstraintID).Any())
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeRequestActionTypeLink.PrecedenceConstraintDoesNotExist(precedenceConstraintID));
            }
        }

        private void CheckIfListSequenceIsDuplicate(List<ServiceTypeActionTypeLinkUpdateModel> actionTypeLinksToBeUpdated)
        {
            //get distinct list sequence value count and see if they are not equal to list count
            if (actionTypeLinksToBeUpdated.Select(x => x.ListSequence).Distinct().Count() != actionTypeLinksToBeUpdated.Count)
            {
                throw new PSRAdminException(ErrorMessages.ServiceTypeRequestActionTypeLink.DuplicateListSequence());
            }
        }

        public IQueryable<ServiceTypeRequestActionTypeLink> AddOrUpdate(int serviceTypeID, List<ServiceTypeActionTypeLinkUpdateModel> actionTypeLinksToBeUpdated, List<int> lstActionTypeLinkIdsToBeDeleted)
        {
            var strActionTypeIdsToBeDeleted = string.Join(",", lstActionTypeLinkIdsToBeDeleted);

            CheckIfListSequenceIsDuplicate(actionTypeLinksToBeUpdated);

            foreach (var actionTypeLink in actionTypeLinksToBeUpdated)
            {
                checkIfActionTypeIsDuplicate(actionTypeLink, actionTypeLinksToBeUpdated, serviceTypeID);

                if (!String.IsNullOrWhiteSpace(actionTypeLink.PrecedenceConstraintRequestActionTypeIDValue))
                {
                    checkIfPrecedenceConstraintValuesAreValid(actionTypeLink, actionTypeLink.RequestActionTypeID.ToString(), 
                        actionTypeLinksToBeUpdated, strActionTypeIdsToBeDeleted, serviceTypeID);
                }
                else
                {
                    actionTypeLink.PrecedenceConstraintRequestActionTypeIDValue = null;
                    actionTypeLink.PrecedenceConstraintLogicalOperatorIsORFlag = null;
                }

                if (actionTypeLink.ServiceTypeRequestActionTypeLinkID == 0)
                {
                    var newActionTypeLink = new ServiceTypeRequestActionTypeLink()
                    {
                        ServiceTypeID = serviceTypeID,
                        RequestActionTypeID = actionTypeLink.RequestActionTypeID,
                        AddActionActiveDirectoryGroupName = actionTypeLink.AddActionActiveDirectoryGroupName,
                        UpdateActionActiveDirectoryGroupName = actionTypeLink.UpdateActionActiveDirectoryGroupName,
                        DeleteActionActiveDirectoryGroupName = actionTypeLink.DeleteActionActiveDirectoryGroupName,
                        MaximumAllowedOcurrence = actionTypeLink.MaximumAllowedOcurrence,
                        ListSequence = actionTypeLink.ListSequence,
                        RequestWorkspaceDisplayCode = actionTypeLink.RequestWorkspaceDisplayCode,
                        PrecedenceConstraintRequestActionTypeIDValue = actionTypeLink.PrecedenceConstraintRequestActionTypeIDValue,
                        PrecedenceConstraintLogicalOperatorIsORFlag = actionTypeLink.PrecedenceConstraintLogicalOperatorIsORFlag
                    };

                    db.ServiceTypeRequestActionTypeLinks.Add(newActionTypeLink);
                }
                else if (actionTypeLink.ServiceTypeRequestActionTypeLinkID > 0)
                {

                    var currentActionTypeLink = Find(actionTypeLink.ServiceTypeRequestActionTypeLinkID).FirstOrDefault();
                    if (currentActionTypeLink == null)
                    {
                        throw new PSRAdminException(ErrorMessages.ServiceTypeRequestActionTypeLink.NotFound(actionTypeLink.ServiceTypeRequestActionTypeLinkID.ToString()));
                    }
                    else
                    {
                        currentActionTypeLink.RequestActionTypeID = actionTypeLink.RequestActionTypeID;
                        currentActionTypeLink.AddActionActiveDirectoryGroupName = actionTypeLink.AddActionActiveDirectoryGroupName;
                        currentActionTypeLink.UpdateActionActiveDirectoryGroupName = actionTypeLink.UpdateActionActiveDirectoryGroupName;
                        currentActionTypeLink.DeleteActionActiveDirectoryGroupName = actionTypeLink.DeleteActionActiveDirectoryGroupName;
                        currentActionTypeLink.MaximumAllowedOcurrence = actionTypeLink.MaximumAllowedOcurrence;
                        currentActionTypeLink.ListSequence = actionTypeLink.ListSequence;
                        currentActionTypeLink.RequestWorkspaceDisplayCode = actionTypeLink.RequestWorkspaceDisplayCode;
                        currentActionTypeLink.PrecedenceConstraintRequestActionTypeIDValue = actionTypeLink.PrecedenceConstraintRequestActionTypeIDValue;
                        currentActionTypeLink.PrecedenceConstraintLogicalOperatorIsORFlag = actionTypeLink.PrecedenceConstraintLogicalOperatorIsORFlag;
                        db.Entry(currentActionTypeLink).State = EntityState.Modified;
                    }
                }
            }

            if (lstActionTypeLinkIdsToBeDeleted.Count > 0)
            {
                //delete keyword from ServiceTypeSearchKeyword table AND ServiceTypeSearchKeywordLink table
                string strDeleteQuery = "DELETE FROM [PSR].[ServiceTypeRequestActionTypeLink] " +
                                        $"WHERE ServiceTypeRequestActionTypeLinkID IN ({strActionTypeIdsToBeDeleted})";

                db.Database.ExecuteSqlCommand(strDeleteQuery);
            }
            db.SaveChanges();

            return db.ServiceTypeRequestActionTypeLinks;
        }
    }
}

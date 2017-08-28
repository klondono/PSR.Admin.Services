using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PublicServiceRequest.Admin.DAL.Models;
using PublicServiceRequest.Admin.BLL.Repositories.Interface;
using PublicServiceRequest.Admin.Common.Models;
using PublicServiceRequest.Admin.BLL.ErrorModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Entity;

namespace PublicServiceRequest.Admin.DAL.Repositories.Implementation
{
    public class ServiceTypeRelationshipDefinitionsRepository : IServiceTypeRelationshipDefinitionsRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<ServiceTypeRelationshipDefinition> Get()
        {
            return db.ServiceTypeRelationshipDefinitions;
        }

        public ServiceTypeRelationshipDefinition Find(int? key)
        {
            if (key == 0)
            {
                return new ServiceTypeRelationshipDefinition();
            }
            return db.ServiceTypeRelationshipDefinitions.Where(serviceTypeRelationshipDefinition => serviceTypeRelationshipDefinition.ServiceTypeRelationshipDefinitionID == key).FirstOrDefault();
        }

        public ServiceTypeRelationshipDefinition Create(ServiceTypeRelationshipDefinition serviceTypeRelationship)
        {
            try
            {
                db.ServiceTypeRelationshipDefinitions.Add(serviceTypeRelationship);
                db.SaveChanges();
            }
            catch (PSRAdminException ex)
            {
                throw new PSRAdminException("Error in ServiceTypeRelationshipDefinitionsRepository Creation: " + ex.ToString());
            }
            if (!IsRelationshipValid())
            {
                Delete(serviceTypeRelationship);
                throw new PSRAdminException(ErrorMessages.ServiceTypeRelationshipDefinition.CircularReference());
            }
            return new ServiceTypeRelationshipDefinition();
        }
        public void SavePatch(ServiceTypeRelationshipDefinition copyCurrentServiceTypeRelationship)
        {
            try
            {
                db.SaveChanges();
            }
            catch (PSRAdminException ex)
            {
                throw new PSRAdminException("Error in ServiceTypeRelationshipDefinitionsRepository Update: " + ex.ToString());
            }
            if (!IsRelationshipValid())
            {
                Update(copyCurrentServiceTypeRelationship);
                throw new PSRAdminException(ErrorMessages.ServiceTypeRelationshipDefinition.CircularReference());
            }
        }

        private void Update(ServiceTypeRelationshipDefinition copyCurrentServiceTypeRelationship)
        {
            try { 
                string strQuery = "UPDATE [PSR].[ServiceTypeRelationshipDefinition] " +
                            $"SET [ServiceTypeParentID] = {copyCurrentServiceTypeRelationship.ServiceTypeParentID} ,[ServiceTypeChildID] = {copyCurrentServiceTypeRelationship.ServiceTypeChildID} ,[ServiceTypeChildStartTriggerID] = {copyCurrentServiceTypeRelationship.ServiceTypeChildStartTriggerID} ,[ServiceTypeChildStartDelay] = {copyCurrentServiceTypeRelationship.ServiceTypeChildStartDelay},[ServiceTypeChildDuration] = {copyCurrentServiceTypeRelationship.ServiceTypeChildDuration} " +
                            $",[ServiceTypeChildRequiredFlag] = '{copyCurrentServiceTypeRelationship.ServiceTypeChildRequiredFlag}',[ServiceTypeChildCheckedByDefaultFlag] = '{copyCurrentServiceTypeRelationship.ServiceTypeChildCheckedByDefaultFlag}',[AdmIsActive] = '{copyCurrentServiceTypeRelationship.AdmIsActive}',[AdmUserAdded] = '{copyCurrentServiceTypeRelationship.AdmUserAdded}',[AdmUserAddedFullName] = '{copyCurrentServiceTypeRelationship.AdmUserAddedFullName}',[AdmDateAdded] = '{copyCurrentServiceTypeRelationship.AdmDateAdded}' " +
                            $",[AdmUserModified] = '{copyCurrentServiceTypeRelationship.AdmUserModified}',[AdmUserModifiedFullName] = '{copyCurrentServiceTypeRelationship.AdmUserModifiedFullName}',[AdmDateModified] = '{copyCurrentServiceTypeRelationship.AdmDateModified}',[AdmUserAddedDomainName] = '{copyCurrentServiceTypeRelationship.AdmUserAddedDomainName}',[AdmUserModifiedDomainName] = '{copyCurrentServiceTypeRelationship.AdmUserModifiedDomainName}' " +
                            $"WHERE ServiceTypeRelationshipDefinitionID = {copyCurrentServiceTypeRelationship.ServiceTypeRelationshipDefinitionID} ";

                db.Database.ExecuteSqlCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw new PSRAdminException($"IMPORTANT!! Make note of ServiceTypeRelationshipDefinitionID {copyCurrentServiceTypeRelationship.ServiceTypeRelationshipDefinitionID} and correct circular reference error manually in database.  Please refer to actual database error : " + ex.ToString());
            }
        }

        public bool RelationshipExists(ServiceTypeRelationshipDefinition serviceTypeRelationship)
        {
            //check if Parent Child or Child Parent relationship already exists between service types
            return db.ServiceTypeRelationshipDefinitions.
                Where(x => (x.ServiceTypeParentID == serviceTypeRelationship.ServiceTypeParentID && x.ServiceTypeChildID == serviceTypeRelationship.ServiceTypeChildID && x.ServiceTypeRelationshipDefinitionID != serviceTypeRelationship.ServiceTypeRelationshipDefinitionID) ||
                (x.ServiceTypeParentID == serviceTypeRelationship.ServiceTypeChildID && x.ServiceTypeChildID == serviceTypeRelationship.ServiceTypeParentID)).Any();
        }
        public void Delete(ServiceTypeRelationshipDefinition serviceTypeRelationship) {

            try
            {
                string strDeleteQuery = $"DELETE FROM [PSR].[ServiceTypeRelationshipDefinition] WHERE ServiceTypeRelationshipDefinitionID = {serviceTypeRelationship.ServiceTypeRelationshipDefinitionID}";
                db.Database.ExecuteSqlCommand(strDeleteQuery);
            }
            catch (PSRAdminException ex)
            {
                throw new PSRAdminException($"IMPORTANT!! Make note of ServiceTypeRelationshipDefinitionID {serviceTypeRelationship.ServiceTypeRelationshipDefinitionID} and correct circular reference error manually in database.  Please refer to actual database error : " + ex.ToString());
            }
        }

        private string GetServiceTypeParentDecendants(int? id)
        {
            //DbRawSqlQuery<string[]> resultsArray = null;
            List<int> resultsArray = null;
            string strQuery = "WITH cte AS (" +
                "SELECT D.[ServiceTypeRelationshipDefinitionID], D.[ServiceTypeChildID], D.[ServiceTypeParentID] FROM [PSR].[ServiceTypeRelationshipDefinition] D " +
                $"WHERE [ServiceTypeParentID] = {id} " +
                "UNION ALL " +
                "SELECT i.[ServiceTypeRelationshipDefinitionID], i.[ServiceTypeChildID], i.[ServiceTypeParentID] FROM [PSR].[ServiceTypeRelationshipDefinition] i " +
                //recursive join
                "INNER JOIN cte c ON c.[ServiceTypeChildID] = i.[ServiceTypeParentID] " +
                ") SELECT ServiceTypeRelationshipDefinitionID FROM CTE ";

            resultsArray = db.Database.SqlQuery<int>(strQuery).ToList();
       
            return string.Join(",", resultsArray);
        }

        private bool IsRelationshipValid()
        {
            string strQuery = "WITH cte AS (" +
                "SELECT D.[ServiceTypeRelationshipDefinitionID], D.[ServiceTypeChildID], D.[ServiceTypeParentID] FROM [PSR].[ServiceTypeRelationshipDefinition] D " +
                "WHERE [ServiceTypeParentID] = 1" +
                "UNION ALL " +
                "SELECT i.[ServiceTypeRelationshipDefinitionID], i.[ServiceTypeChildID], i.[ServiceTypeParentID] FROM [PSR].[ServiceTypeRelationshipDefinition] i " +
                //recursive join
                "INNER JOIN cte c ON c.[ServiceTypeChildID] = i.[ServiceTypeParentID] " +
                ") SELECT ServiceTypeRelationshipDefinitionID FROM CTE ";

            try
            {
                return db.Database.SqlQuery<int>(strQuery).ToList().Count() >= 0;
            }
            catch (Exception ex)
            {
                dynamic innerException = ex.InnerException;
                if (innerException is SqlException)
                {
                    if (innerException.Number == 530)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private string GetDeleteQuery(ServiceTypeRelationshipDefinition serviceTypeRelationship)
        {
            return $"DELETE FROM [PSR].[ServiceTypeRelationshipDefinition] WHERE ServiceTypeRelationshipDefinitionID = {serviceTypeRelationship.ServiceTypeRelationshipDefinitionID} ";
        }

        public void DeleteWithDecendants(ServiceTypeRelationshipDefinition serviceTypeRelationship)
        {
            var decendants = GetServiceTypeParentDecendants(serviceTypeRelationship.ServiceTypeChildID);
            string strDeleteQuery = GetDeleteQuery(serviceTypeRelationship);

            if (!String.IsNullOrWhiteSpace(decendants))
            {
                //Experiment prevent deletion of child if it has another parent besides this one
                //string strCheckIfChildHasAnotherParentQuery = $"SELECT R.ServiceTypeChildID FROM [PSR].[ServiceTypeRelationshipDefinition] R "+
                //    $"WHERE R.ServiceTypeParentID <> {serviceTypeRelationship.ServiceTypeChildID} AND R.ServiceTypeChildID IN (SELECT R2.ServiceTypeChildID FROM "+
                //    $"[PSR].[ServiceTypeRelationshipDefinition] R2 WHERE R2.ServiceTypeRelationshipDefinitionID IN ({decendants}) AND R2.ServiceTypeParentID = {serviceTypeRelationship.ServiceTypeChildID})";
                //var hasAnotherParent = db.Database.SqlQuery<int>(strCheckIfChildHasAnotherParentQuery).Any();
                //if (!hasAnotherParent)
                //{
                    strDeleteQuery += $"DELETE FROM [PSR].[ServiceTypeRelationshipDefinition] WHERE ServiceTypeRelationshipDefinitionID IN ({decendants})";
                //}                
            }
                
            db.Database.ExecuteSqlCommand(strDeleteQuery);
        }
        public void DeleteAndConnectDecendantsToRoot(ServiceTypeRelationshipDefinition serviceTypeRelationship)
        {
            string strDeleteQuery = GetDeleteQuery(serviceTypeRelationship) +
                "UPDATE [PSR].[ServiceTypeRelationshipDefinition] SET ServiceTypeParentID = 1 " +
                $"WHERE ServiceTypeRelationshipDefinitionID IN (SELECT ServiceTypeRelationshipDefinitionID FROM [PSR].[ServiceTypeRelationshipDefinition] WHERE ServiceTypeParentID = {serviceTypeRelationship.ServiceTypeChildID})";

            db.Database.ExecuteSqlCommand(strDeleteQuery);
        }
        public void DeleteAndConnectDecendantsToGrandParent(ServiceTypeRelationshipDefinition serviceTypeRelationship)
        {
            string strDeleteQuery = GetDeleteQuery(serviceTypeRelationship) +
            $"UPDATE [PSR].[ServiceTypeRelationshipDefinition] SET ServiceTypeParentID = {serviceTypeRelationship.ServiceTypeParentID} " +
            $"WHERE ServiceTypeRelationshipDefinitionID IN (SELECT ServiceTypeRelationshipDefinitionID FROM [PSR].[ServiceTypeRelationshipDefinition] WHERE ServiceTypeParentID = {serviceTypeRelationship.ServiceTypeChildID})";

            db.Database.ExecuteSqlCommand(strDeleteQuery);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PublicServiceRequest.Admin.DAL.Models;
using PublicServiceRequest.Admin.BLL.Repositories.Interface;
using PublicServiceRequest.Admin.Common.Models;
using PublicServiceRequest.Admin.BLL.ErrorModel;
using System.Web.OData;
using PublicServiceRequest.Admin.BLL.Helpers;
using System.Web;

namespace PublicServiceRequest.Admin.DAL.Repositories.Implementation
{
    public class ServiceTypesRepository : IServiceTypesRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<ServiceType> Get()
        {
            return db.ServiceTypes;
        }

        public ServiceType Find(int? key)
        {
            if (key == 0)
            {
                return new ServiceType();
            }
            return db.ServiceTypes.Where(serviceType => serviceType.ServiceTypeID == key).FirstOrDefault();
        }

        public int Create(ServiceType serviceType)
        {
            try
            {
                db.ServiceTypes.Add(serviceType);
                db.SaveChanges();
                return serviceType.ServiceTypeID;
            }
            catch(PSRAdminException ex)
            {
                throw new PSRAdminException("Error in ServiceTypesRepository Creation: " + ex.ToString());
            }
        }

        public int Clone(int serviceTypeID)
        {
            try
            {
                var guidUserID = IdentityHelper.GetUserID(HttpContext.Current.User.Identity);
                var strUserFullName = IdentityHelper.GetFullName(HttpContext.Current.User.Identity);
                var strUserDomainName = $"MIAMIDADE\\{HttpContext.Current.User.Identity}";
                var dtNow = DateTime.Now;

                var serviceType = db.ServiceTypes.Where(x => x.ServiceTypeID == serviceTypeID).FirstOrDefault();

                var newServiceType = new ServiceType()
                {
                    ServiceTypeOwnerGroupID = serviceType.ServiceTypeOwnerGroupID,
                    DefaultRequestStatusID = serviceType.DefaultRequestStatusID,
                    EscalationExpectedStatusID = serviceType.EscalationExpectedStatusID,
                    ServiceTypeNumber = serviceType.ServiceTypeNumber,
                    ServiceTypeOwnerGroupOverrideID = serviceType.ServiceTypeOwnerGroupOverrideID,
                    ServiceTypeOwnerGroupOverrideMonthDayFrom = serviceType.ServiceTypeOwnerGroupOverrideMonthDayFrom,
                    ServiceTypeOwnerGroupOverrideMonthDayTo = serviceType.ServiceTypeOwnerGroupOverrideMonthDayTo,
                    ServiceTypeName = "Copy of " + serviceType.ServiceTypeName,
                    ServiceTypeDescription = serviceType.ServiceTypeDescription,
                    ServiceTypeDefaultDuration = serviceType.ServiceTypeDefaultDuration,
                    ServiceTypeAssigneeDependantOnPropertyFlag = serviceType.ServiceTypeAssigneeDependantOnPropertyFlag,
                    ServiceTypeIncludePropertyInfoFlag = serviceType.ServiceTypeIncludePropertyInfoFlag,
                    ServiceTypeIncludeFirstActionCommentFlag = serviceType.ServiceTypeIncludeFirstActionCommentFlag,
                    ServiceTypeShowAsStandaloneServiceFlag = serviceType.ServiceTypeShowAsStandaloneServiceFlag,
                    SelectableOnServiceTypeUpdateFlag = serviceType.SelectableOnServiceTypeUpdateFlag,
                    ServiceTypeParentClosesWhenChildrenClosedFlag = serviceType.ServiceTypeParentClosesWhenChildrenClosedFlag,
                    ServiceTypeConcurrentCreationOfChildrenFlag = serviceType.ServiceTypeConcurrentCreationOfChildrenFlag,
                    ServiceTypeAvailableToActiveDirectoryGroupName = serviceType.ServiceTypeAvailableToActiveDirectoryGroupName,
                    ServiceTypeAssigneeDependantOnOriginFlag = serviceType.ServiceTypeAssigneeDependantOnOriginFlag,
                    ServiceTypeDependantOriginID = serviceType.ServiceTypeDependantOriginID,
                    ServiceTypeOwnerGroupOverrideOriginBased = serviceType.ServiceTypeOwnerGroupOverrideOriginBased,
                    DefaultRequestFolioTypeID = serviceType.DefaultRequestFolioTypeID,
                    ForceRequestFolioType = serviceType.ForceRequestFolioType
                };
                db.ServiceTypes.Add(newServiceType);
                db.SaveChanges();

                string strActionTypelinkQuery = "INSERT INTO [PSR].[ServiceTypeRequestActionTypeLink] ([ServiceTypeID],[RequestActionTypeID],[AddActionActiveDirectoryGroupName],[UpdateActionActiveDirectoryGroupName],[DeleteActionActiveDirectoryGroupName] " +
                ",[MaximumAllowedOcurrence],[ListSequence],[RequestWorkspaceDisplayCode],[PrecedenceConstraintRequestActionTypeIDValue],[PrecedenceConstraintLogicalOperatorIsORFlag],[AdmIsActive],[AdmUserAdded],[AdmUserAddedFullName],[AdmDateAdded],[AdmUserAddedDomainName]) " +
                $"SELECT {newServiceType.ServiceTypeID} ,[RequestActionTypeID],[AddActionActiveDirectoryGroupName],[UpdateActionActiveDirectoryGroupName],[DeleteActionActiveDirectoryGroupName],[MaximumAllowedOcurrence],[ListSequence],[RequestWorkspaceDisplayCode],[PrecedenceConstraintRequestActionTypeIDValue] " +
                $",[PrecedenceConstraintLogicalOperatorIsORFlag],[AdmIsActive],'{guidUserID}','{strUserFullName}','{dtNow}','{strUserDomainName}' " +
                $"FROM [PSR].[ServiceTypeRequestActionTypeLink] WHERE [ServiceTypeID] = {serviceTypeID}";

                
                string strCustomFieldQuery = " INSERT INTO [PSR].[ServiceTypeCustomField] ([ServiceTypeID],[CustomFieldTypeID],[CustomFieldDataTypeID],[LabelName],[PlaceholderText],[TextAlignment],[Description],[InputSequence],[RequiredFlag] " +
                ",[TooltipMessage],[GroupingIdentifier1],[GroupingIdentifier2],[AdmIsActive],[AdmUserAdded],[AdmUserAddedFullName],[AdmDateAdded],[AdmUserAddedDomainName]) " +
                $"SELECT {newServiceType.ServiceTypeID},[CustomFieldTypeID],[CustomFieldDataTypeID],[LabelName],[PlaceholderText],[TextAlignment],[Description],[InputSequence],[RequiredFlag] " +
                $",[TooltipMessage],[GroupingIdentifier1],[GroupingIdentifier2],[AdmIsActive],'{guidUserID}','{strUserFullName}','{dtNow}','{strUserDomainName}' " +
                $"FROM [PSR].[ServiceTypeCustomField] WHERE [ServiceTypeID] = {serviceTypeID} AND [AdmIsActive] = 'Y'";

                db.Database.ExecuteSqlCommand(strActionTypelinkQuery + strCustomFieldQuery);
                return newServiceType.ServiceTypeID;
            }
            catch (PSRAdminException ex)
            {
                throw new PSRAdminException("Error in ServiceTypesRepository Clone: " + ex.ToString());
            }
        }

        public void SavePatch()
        {
            try
            {
                db.SaveChanges();
            }
            catch (PSRAdminException ex)
            {
                throw new PSRAdminException("Error on ServiceTypesRepository Patch: " + ex.ToString());
            }
        }

        public bool IsParent(int? key)
        {
            return db.ServiceTypeRelationshipDefinitions.Where(serviceTypeRelationshipDefinition => serviceTypeRelationshipDefinition.ServiceTypeParentID == key).Count() > 0;
        }

        public bool BusinessAreaIsVisibleOnPSRCreation(Guid? key)
        {
            return db.ServiceTypeOwnerGroups.Where(serviceTypeOwnerGroup => serviceTypeOwnerGroup.ServiceTypeOwnerGroupID == key)?.FirstOrDefault().SelectableOnRequestCreationFlag == true;
        }

        //IQueryable<int> Delete(ServiceType serviceType);

    }
}

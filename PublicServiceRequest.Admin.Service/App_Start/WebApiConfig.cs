using Microsoft.OData.Edm;
using PublicServiceRequest.Admin.BLL.Models;
using PublicServiceRequest.Admin.Common.Models;
using PublicServiceRequest.Admin.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace PublicServiceRequest.Admin.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", null, GetEdmModel());
            //to allow filtering, selection on global scale
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
        }

        private static IEdmModel GetEdmModel()
        {

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.Namespace = "PSR";
            builder.EntitySet<ServiceTypeCustomField>("ServiceTypeCustomFields");
            builder.EntitySet<ServiceTypeOwnerGroup>("ServiceTypeOwnerGroups");
            builder.EntitySet<ServiceTypeOwnerGroupLocation>("ServiceTypeOwnerGroupLocations");
            builder.EntitySet<ServiceTypeOwnerGroupMember>("ServiceTypeOwnerGroupMembers");
            builder.EntitySet<ServiceTypeRelationshipDefinition>("ServiceTypeRelationshipDefinitions");
            builder.EntitySet<ServiceTypeRequestActionTypeLink>("ServiceTypeRequestActionTypeLinks");
            builder.EntitySet<ApplicationSource>("ApplicationSources");
            builder.EntitySet<ServiceTypeSearchKeyword>("ServiceTypeSearchKeywords");
            builder.EntitySet<AttachmentType>("AttachmentTypes");
            builder.EntitySet<ServiceTypeSearchKeywordLink>("ServiceTypeSearchKeywordLinks");
            builder.EntitySet<CustomFieldDataType>("CustomFieldDataTypes");
            builder.EntitySet<CustomFieldSelectListItem>("CustomFieldSelectListItems");
            builder.EntitySet<CustomFieldType>("CustomFieldTypes");
            builder.EntitySet<RequestActionType>("RequestActionTypes");
            builder.EntitySet<RequestActionTypeCustomField>("RequestActionTypeCustomFields");
            builder.EntitySet<RequestFolioType>("RequestFolioTypes");
            builder.EntitySet<RequestOrigin>("RequestOrigins");
            builder.EntitySet<RequestPriority>("RequestPriorities");
            builder.EntitySet<RequestStatus>("RequestStatuses");
            builder.EntitySet<RequestTaxpayerPreferredLanguage>("RequestTaxpayerPreferredLanguages");
            builder.EntitySet<RequestType>("RequestTypes");
            builder.EntitySet<ServiceType>("ServiceTypes");
            builder.EntitySet<ServiceTypeChildStartTrigger>("ServiceTypeChildStartTriggers");
            builder.EntitySet<DbObject>("DbObjects");

            ConfigureCustomActions(builder);
            ConfigureCustomFunctions(builder);

            var edmModel = builder.GetEdmModel();
            return edmModel;
        }

        private static void ConfigureCustomActions(ODataConventionModelBuilder builder)
        {
            //https://blogs.msdn.microsoft.com/odatateam/2014/12/08/tutorial-sample-functions-actions-in-web-api-v2-2-for-odata-v4-0-type-scenario/
            ActionConfiguration addOrUpdateKeywords = builder.EntityType<ServiceTypeSearchKeyword>().Collection.Action("AddOrUpdate");
            addOrUpdateKeywords.Parameter<ServiceTypeSearchKeywordContainerModel>("serviceTypeSearchKeywordContainerModel");
            addOrUpdateKeywords.ReturnsCollectionFromEntitySet<ServiceTypeSearchKeywordLinkModel>("createdServiceTypeSearchKeyword");

            ActionConfiguration addOrUpdateActionTypeLinks = builder.EntityType<ServiceTypeRequestActionTypeLink>().Collection.Action("AddOrUpdate");
            addOrUpdateActionTypeLinks.Parameter<ServiceTypeActionTypeLinkContainerModel>("serviceTypeActionTypeLinkContainerModel");
            addOrUpdateActionTypeLinks.ReturnsCollectionFromEntitySet<ServiceTypeRequestActionTypeLink>("createdActionTypeLink");

            ActionConfiguration deleteRelationship = builder.EntityType<ServiceTypeRelationshipDefinition>().Collection.Action("DeleteRelationship");
            deleteRelationship.Parameter<ServiceTypeRelationshipDefinitionDeletionModel>("serviceTypeRelationshipDefinitionDeletionModel");

            ActionConfiguration cloneServiceType = builder.EntityType<ServiceType>().Collection.Action("Clone");
            cloneServiceType.Parameter<int>("serviceTypeID");
            cloneServiceType.Returns<int>();

            //ActionConfiguration closePSR = builder.EntityType<PublicServiceRequestBusinessModel>().Collection.Action("Close");
            //closePSR.Parameter<int>("Id");
            //closePSR.Parameter<string>("Comments");
            //closePSR.Parameter<int>("ApplicationSourceID");
            //closePSR.Parameter<string>("UserName");

            //ActionConfiguration reassignPSR = builder.EntityType<PublicServiceRequestBusinessModel>().Collection.Action("Reassign");
            //reassignPSR.Parameter<int>("Id");
            //reassignPSR.Parameter<string>("Comments");
            //reassignPSR.Parameter<int>("ApplicationSourceID");
            //reassignPSR.Parameter<string>("UserOrGroupID");
            //reassignPSR.Parameter<bool>("AssigneeIsGroup");
            //reassignPSR.Parameter<string>("UserName");

            //ActionConfiguration updatePSR = builder.EntityType<PublicServiceRequestBusinessModel>().Collection.Action("Update");
            //updatePSR.Parameter<UpdatePSR>("UpdatePSR");
        }

        private static void ConfigureCustomFunctions(ODataConventionModelBuilder builder)
        {
            //https://blogs.msdn.microsoft.com/odatateam/2014/12/08/tutorial-sample-functions-actions-in-web-api-v2-2-for-odata-v4-0-type-scenario/

        }
    }
}

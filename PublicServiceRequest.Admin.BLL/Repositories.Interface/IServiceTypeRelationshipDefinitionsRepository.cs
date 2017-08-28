using PublicServiceRequest.Admin.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServiceRequest.Admin.BLL.Repositories.Interface
{
    public interface IServiceTypeRelationshipDefinitionsRepository
    {
        IQueryable<ServiceTypeRelationshipDefinition> Get();
        ServiceTypeRelationshipDefinition Find(int? key);
        ServiceTypeRelationshipDefinition Create(ServiceTypeRelationshipDefinition serviceTypeRelationship);
        void SavePatch(ServiceTypeRelationshipDefinition copyCurrentServiceTypeRelationship);
        bool RelationshipExists(ServiceTypeRelationshipDefinition serviceTypeRelationship);
        void Delete(ServiceTypeRelationshipDefinition serviceTypeRelationship);
        void DeleteWithDecendants(ServiceTypeRelationshipDefinition serviceTypeRelationship);
        void DeleteAndConnectDecendantsToRoot(ServiceTypeRelationshipDefinition serviceTypeRelationship);
        void DeleteAndConnectDecendantsToGrandParent(ServiceTypeRelationshipDefinition serviceTypeRelationship);
    }
}

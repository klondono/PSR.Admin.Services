using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServiceRequest.Admin.BLL.ErrorModel
{
    public class ErrorMessages
    {
        public static ServiceTypeMessages ServiceType => new ServiceTypeMessages();
        public static ServiceTypeSearchKeywordMessages ServiceTypeSearchKeyword => new ServiceTypeSearchKeywordMessages();

        public static ServiceTypeRequestActionTypeLinkMessages ServiceTypeRequestActionTypeLink => new ServiceTypeRequestActionTypeLinkMessages();
        public static ServiceTypeCustomFieldMessages ServiceTypeCustomField => new ServiceTypeCustomFieldMessages();

        public static ServiceTypeRelationshipDefinitionMessages ServiceTypeRelationshipDefinition => new ServiceTypeRelationshipDefinitionMessages();

        public static ActionTypeCustomFieldMessages ActionTypeCustomField => new ActionTypeCustomFieldMessages();

        public static UnauthorizedAccessExceptionMessages UnauthorizedAccess => new UnauthorizedAccessExceptionMessages();
    }

    public class UnauthorizedAccessExceptionMessages
    {
        public string Unauthorized(string unauthorizedUser) => $"Unauthorized User: {unauthorizedUser}.";
    }
    public class ServiceTypeMessages
    {
        //public string InvalidYear(long Year) => $"Invalid Case Year:{Year}";
        public string NotFound() => $"Service type not found or it has been deleted";
        public string InvalidOwnerGroupSelection() => $"Make sure default business area selected appears in PSR form as a select list option.";
    }

    public class ServiceTypeRequestActionTypeLinkMessages
    {
        public string NotFound(string requestActionTypeLinkID) => $"Request action type link id {requestActionTypeLinkID} not found or it has been deleted";
        public string PrecedenceConstraintRefersToSelf(string requestActionTypeLinkID) => $"Invalid preceding action type id entered: {requestActionTypeLinkID}.  Action Type cannot refer to itself";
        public string PrecedenceConstraintWillBeDeleted() => $"You are saving a preceding action type id that refers to an action type link that is being deleted.";
        public string PrecedenceConstraintDoesNotExist(string requestActionTypeID) => $"Request action type with id {requestActionTypeID} is not linked to this service type.";
        public string DuplicateLink(int requestActionTypeLinkID) => $"Request Action Type with id: {requestActionTypeLinkID} is already linked to this service type.";
        public string PrecedenceRuleIsNull(int requestActionTypeID) => $"Precedence action type rule for action type id: {requestActionTypeID} is null.";
        public string DuplicateListSequence() => $"List sequence for one or more action types is duplicated.";
    }

    public class ServiceTypeSearchKeywordMessages
    {
        public string NotFound(string keywordID) => $"ServiceTypeSearchKeywordID {keywordID} not found or has been deleted";
        public string GeneralException(string errorMsg) => $"ServiceTypeSearchKeywordsRepository AddOrUpdate Error: {errorMsg}";
    }

    public class ServiceTypeCustomFieldMessages
    {
        public string NotFound() => $"Custom field not found or it has been deleted";
        public string InvalidInputSequence() => $"All input sequences must be distinct.";
    }

    public class ActionTypeCustomFieldMessages
    {
        public string NotFound() => $"Custom field not found or it has been deleted";
        public string InvalidInputSequence() => $"All input sequences must be distinct.";
    }

    public class ServiceTypeRelationshipDefinitionMessages
    {
        public string NotFound() => $"Relationship not found or it has been deleted";
        public string RelationshipExists() => $"Parent child service type relationship already exists.";
        public string CircularReference() => $"Workflow relationship was not saved because it will result in a circular reference.";
        public string SelfReference() => $"Service type cannot link to itself.";
    }
}

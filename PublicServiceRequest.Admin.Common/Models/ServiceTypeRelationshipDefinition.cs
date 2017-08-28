namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.ServiceTypeRelationshipDefinition")]
    public partial class ServiceTypeRelationshipDefinition : BaseModel
    {
        public ServiceTypeRelationshipDefinition()
        {
            ServiceTypeRelationshipDefinitionID = 0;
            ServiceTypeParentID = 0;
            ServiceTypeChildStartTriggerID = 2;
            ServiceTypeChildStartDelay = 0;
            ServiceTypeChildDuration = 0;
            ServiceTypeChildRequiredFlag = true;
            ServiceTypeChildCheckedByDefaultFlag = true;
        }
        public int ServiceTypeRelationshipDefinitionID { get; set; }

        public int? ServiceTypeParentID { get; set; }

        public int? ServiceTypeChildID { get; set; }

        public int? ServiceTypeChildStartTriggerID { get; set; }

        public int? ServiceTypeChildStartDelay { get; set; }

        public int? ServiceTypeChildDuration { get; set; }

        public bool? ServiceTypeChildRequiredFlag { get; set; }

        public bool? ServiceTypeChildCheckedByDefaultFlag { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual ServiceType ServiceType1 { get; set; }

        public virtual ServiceTypeChildStartTrigger ServiceTypeChildStartTrigger { get; set; }
    }
}

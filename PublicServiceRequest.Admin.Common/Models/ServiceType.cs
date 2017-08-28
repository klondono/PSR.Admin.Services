namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    //using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.ServiceType")]
    public partial class ServiceType : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceType()
        {
            ServiceTypeAssigneeDependantOnPropertyFlag = false;
            ServiceTypeIncludePropertyInfoFlag = false;
            ServiceTypeIncludeFirstActionCommentFlag = false;
            ServiceTypeShowAsStandaloneServiceFlag = true;
            SelectableOnServiceTypeUpdateFlag = true;
            ServiceTypeParentClosesWhenChildrenClosedFlag = false;
            ServiceTypeConcurrentCreationOfChildrenFlag = false;
            ServiceTypeAssigneeDependantOnOriginFlag = false;
            ForceRequestFolioType = false;
            DefaultRequestStatusID = null;
            EscalationExpectedStatusID = null;
            DefaultRequestFolioTypeID = null;
            ServiceTypeDependantOriginID = null;
            AttachmentTypes = new HashSet<AttachmentType>();
            ServiceTypeCustomFields = new HashSet<ServiceTypeCustomField>();
            ServiceTypeRelationshipDefinitions = new HashSet<ServiceTypeRelationshipDefinition>();
            ServiceTypeRelationshipDefinitions1 = new HashSet<ServiceTypeRelationshipDefinition>();
            ServiceTypeRequestActionTypeLinks = new HashSet<ServiceTypeRequestActionTypeLink>();
            ServiceTypeSearchKeywordLinks = new HashSet<ServiceTypeSearchKeywordLink>();
        }

        public int ServiceTypeID { get; set; }

        public Guid? ServiceTypeOwnerGroupID { get; set; }

        public int? DefaultRequestStatusID { get; set; }

        public int? EscalationExpectedStatusID { get; set; }

        public int ServiceTypeNumber { get; set; }

        public Guid? ServiceTypeOwnerGroupOverrideID { get; set; }

        public string ServiceTypeOwnerGroupOverrideMonthDayFrom { get; set; }

        public string ServiceTypeOwnerGroupOverrideMonthDayTo { get; set; }

        public string ServiceTypeName { get; set; }

        public string ServiceTypeDescription { get; set; }

        public int? ServiceTypeDefaultDuration { get; set; }

        public bool? ServiceTypeAssigneeDependantOnPropertyFlag { get; set; }

        public bool? ServiceTypeIncludePropertyInfoFlag { get; set; }

        public bool? ServiceTypeIncludeFirstActionCommentFlag { get; set; }

        public bool? ServiceTypeShowAsStandaloneServiceFlag { get; set; }

        public bool SelectableOnServiceTypeUpdateFlag { get; set; }

        public bool? ServiceTypeParentClosesWhenChildrenClosedFlag { get; set; }

        public bool ServiceTypeConcurrentCreationOfChildrenFlag { get; set; }

        public string ServiceTypeAvailableToActiveDirectoryGroupName { get; set; }

        public bool ServiceTypeAssigneeDependantOnOriginFlag { get; set; }

        public int? ServiceTypeDependantOriginID { get; set; }

        public Guid? ServiceTypeOwnerGroupOverrideOriginBased { get; set; }

        public int? DefaultRequestFolioTypeID { get; set; }

        public bool ForceRequestFolioType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttachmentType> AttachmentTypes { get; set; }

        public virtual RequestStatus RequestStatusDefault { get; set; }

        public virtual RequestStatus RequestStatusEscalation { get; set; }

        public virtual ServiceTypeOwnerGroup ServiceTypeOwnerGroup { get; set; }

        public virtual ServiceTypeOwnerGroup ServiceTypeOwnerGroupOverride { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeCustomField> ServiceTypeCustomFields { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeRelationshipDefinition> ServiceTypeRelationshipDefinitions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeRelationshipDefinition> ServiceTypeRelationshipDefinitions1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeRequestActionTypeLink> ServiceTypeRequestActionTypeLinks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeSearchKeywordLink> ServiceTypeSearchKeywordLinks { get; set; }
    }
}

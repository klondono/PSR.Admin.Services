namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.ServiceTypeChildStartTrigger")]
    public partial class ServiceTypeChildStartTrigger : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceTypeChildStartTrigger()
        {
            ServiceTypeRelationshipDefinitions = new HashSet<ServiceTypeRelationshipDefinition>();
        }

        public int ServiceTypeChildStartTriggerID { get; set; }

        [StringLength(25)]
        public string ServiceTypeChildStartTriggerName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeRelationshipDefinition> ServiceTypeRelationshipDefinitions { get; set; }
    }
}

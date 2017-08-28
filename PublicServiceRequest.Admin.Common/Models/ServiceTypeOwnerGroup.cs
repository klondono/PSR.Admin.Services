namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.ServiceTypeOwnerGroup")]
    public partial class ServiceTypeOwnerGroup : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceTypeOwnerGroup()
        {
            ServiceTypes = new HashSet<ServiceType>();
            ServiceTypes1 = new HashSet<ServiceType>();
        }

        public Guid ServiceTypeOwnerGroupID { get; set; }

        public int? ServiceTypeOwnerGroupLocationID { get; set; }

        [Required]
        [StringLength(100)]
        public string ServiceTypeOwnerGroupName { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupDescription { get; set; }

        [StringLength(1000)]
        public string ServiceTypeOwnerAvailableToActiveDirectoryGroupName { get; set; }

        [StringLength(1000)]
        public string ServiceTypeOwnerActiveDirectoryGroupName { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupMainEmail { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupNotificationEmail { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupEscalationEmail { get; set; }

        [StringLength(25)]
        public string ServiceTypeOwnerGroupPhoneNo { get; set; }

        public int? ServiceTypeOwnerGroupDistrictNo { get; set; }

        public bool? SelectableOnRequestCreationFlag { get; set; }

        public bool? SelectableOnRequestReassignmentFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceType> ServiceTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceType> ServiceTypes1 { get; set; }

        public virtual ServiceTypeOwnerGroupLocation ServiceTypeOwnerGroupLocation { get; set; }
    }
}

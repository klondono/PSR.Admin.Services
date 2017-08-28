namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.RequestStatus")]
    public partial class RequestStatus : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestStatus()
        {
            ServiceTypes = new HashSet<ServiceType>();
            ServiceTypes1 = new HashSet<ServiceType>();
        }

        [Key]
        public int RequestStatusID { get; set; }

        [StringLength(50)]
        public string RequestStatusName { get; set; }

        [StringLength(500)]
        public string RequestStatusDescription { get; set; }

        [StringLength(20)]
        public string RequestStatusColor { get; set; }

        public bool? StatusReopensRequestFlag { get; set; }

        public bool? StatusClosesRequestFlag { get; set; }

        public bool? SelectableOnRequestStatusChangeListFlag { get; set; }

        public bool? SystemReservedFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceType> ServiceTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceType> ServiceTypes1 { get; set; }
    }
}

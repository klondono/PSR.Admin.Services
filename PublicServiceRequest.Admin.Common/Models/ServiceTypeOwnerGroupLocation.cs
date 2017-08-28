namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.ServiceTypeOwnerGroupLocation")]
    public partial class ServiceTypeOwnerGroupLocation : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceTypeOwnerGroupLocation()
        {
            ServiceTypeOwnerGroups = new HashSet<ServiceTypeOwnerGroup>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceTypeOwnerGroupLocationID { get; set; }

        [StringLength(50)]
        public string ServiceTypeOwnerGroupLocationName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeOwnerGroup> ServiceTypeOwnerGroups { get; set; }
    }
}

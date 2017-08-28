namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("PSR.ServiceTypeSearchKeyword")]
    public partial class ServiceTypeSearchKeyword : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceTypeSearchKeyword()
        {
            ServiceTypeSearchKeywordLinks = new HashSet<ServiceTypeSearchKeywordLink>();
        }

        public int ServiceTypeSearchKeywordID { get; set; }

        [StringLength(50)]
        public string ServiceTypeSearchKeywordName { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeSearchKeywordLink> ServiceTypeSearchKeywordLinks { get; set; }
    }
}

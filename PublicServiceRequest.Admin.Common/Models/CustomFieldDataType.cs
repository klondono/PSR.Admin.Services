namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.CustomFieldDataType")]
    public partial class CustomFieldDataType: BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomFieldDataType()
        {
            ServiceTypeCustomFields = new HashSet<ServiceTypeCustomField>();
            RequestActionTypeCustomFields = new HashSet<RequestActionTypeCustomField>();
        }

        public int CustomFieldDataTypeID { get; set; }

        [StringLength(50)]
        public string CustomFieldDataTypeName { get; set; }

        [StringLength(255)]
        public string CustomFieldDataTypeDescription { get; set; }

        [StringLength(2000)]
        public string RegularExpression { get; set; }

        [StringLength(1000)]
        public string ErrorMessage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeCustomField> ServiceTypeCustomFields { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestActionTypeCustomField> RequestActionTypeCustomFields { get; set; }
    }
}

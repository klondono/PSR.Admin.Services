namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.CustomFieldSelectListItem")]
    public partial class CustomFieldSelectListItem : BaseModel
    {
        public int CustomFieldSelectListItemID { get; set; }

        public int CustomFieldTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomFieldSelectListItemLabel { get; set; }

        [Required]
        [StringLength(1000)]
        public string CustomFieldSelectListItemValue { get; set; }

        public int ListSequence { get; set; }

        public virtual CustomFieldType CustomFieldType { get; set; }
    }
}

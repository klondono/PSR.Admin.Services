namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.AttachmentType")]
    public partial class AttachmentType : BaseModel
    {
        public int AttachmentTypeID { get; set; }

        public int ServiceTypeID { get; set; }

        [StringLength(50)]
        public string AttachmentTypeName { get; set; }

        [StringLength(255)]
        public string AttachmentDescription { get; set; }

        public virtual ServiceType ServiceType { get; set; }
    }
}

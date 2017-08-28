namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.RequestType")]
    public partial class RequestType : BaseModel
    {
        public int RequestTypeID { get; set; }

        [StringLength(50)]
        public string RequestTypeName { get; set; }

        [StringLength(255)]
        public string RequestTypeDescription { get; set; }
    }
}

namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.RequestPriority")]
    public partial class RequestPriority : BaseModel
    {
        public int RequestPriorityID { get; set; }

        [StringLength(50)]
        public string RequestPriorityName { get; set; }

        [StringLength(255)]
        public string RequestPriorityDescription { get; set; }

    }
}

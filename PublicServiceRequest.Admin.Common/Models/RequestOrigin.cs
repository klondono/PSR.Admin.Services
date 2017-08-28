namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.RequestOrigin")]
    public partial class RequestOrigin : BaseModel
    {
        public int RequestOriginID { get; set; }

        [StringLength(50)]
        public string RequestOriginName { get; set; }

        [StringLength(255)]
        public string RequestOriginDescription { get; set; }

        [StringLength(1000)]
        public string AutoSelectedForActiveDirectoryGroup { get; set; }

        public bool? ForceAutoSelectedOriginFlag { get; set; }

        public bool? DisableProgressNotificationForAutoSelectedGroupFlag { get; set; }

    }
}

namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.RequestFolioType")]
    public partial class RequestFolioType : BaseModel
    {
        public int RequestFolioTypeID { get; set; }

        [StringLength(50)]
        public string RequestFolioTypeName { get; set; }

        [StringLength(255)]
        public string RequestFoliotypeDescription { get; set; }

    }
}

namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PSR.ApplicationSource")]
    public partial class ApplicationSource : BaseModel
    {
        public int ApplicationSourceID { get; set; }

        [StringLength(100)]
        public string ApplicationSourceName { get; set; }

    }
}

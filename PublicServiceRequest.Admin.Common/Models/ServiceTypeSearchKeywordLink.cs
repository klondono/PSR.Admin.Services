namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.ServiceTypeSearchKeywordLink")]
    public partial class ServiceTypeSearchKeywordLink : BaseModel
    {
        public int ServiceTypeSearchKeywordLinkID { get; set; }

        public int? ServiceTypeID { get; set; }

        public int? ServiceTypeSearchKeywordID { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual ServiceTypeSearchKeyword ServiceTypeSearchKeyword { get; set; }
    }
}

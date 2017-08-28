namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.ServiceTypeOwnerGroupMember")]
    public partial class ServiceTypeOwnerGroupMember : BaseModel
    {
        public int ServiceTypeOwnerGroupMemberID { get; set; }

        public int? ServiceTypeOwnerGroupID { get; set; }

        public int? MemberID { get; set; }
    }
}

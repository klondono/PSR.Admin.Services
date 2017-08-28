namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.RequestTaxpayerPreferredLanguage")]
    public partial class RequestTaxpayerPreferredLanguage : BaseModel
    {
        public int RequestTaxpayerPreferredLanguageID { get; set; }

        [StringLength(50)]
        public string RequestTaxpayerPreferredLanguageName { get; set; }

        [StringLength(255)]
        public string RequestTaxpayerPreferredLanguageDescription { get; set; }

    }
}

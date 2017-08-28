namespace PublicServiceRequest.Admin.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PSR.RequestActionType")]
    public partial class RequestActionType : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestActionType()
        {
            BackgroundColor = "#005580";//set default color
            TextColor = "#ffffff";//set default color
            ChangeRequestStatusFlag = false;
            ReassignRequestFlag = false;
            AllowReplicationFlag = false;
            AllowUpdateOfServiceTypeFlag = false;
            AllowUpdateOfRequestFolioFlag = false;
            ByPassClientSideValidationFlag = false;
            DisplayFlag = true;
            UploadDocumentFlag = false;
            SystemReservedFlag = false;
            RequestActionTypeCustomFields = new HashSet<RequestActionTypeCustomField>();
            ServiceTypeRequestActionTypeLinks = new HashSet<ServiceTypeRequestActionTypeLink>();
        }

        public int RequestActionTypeID { get; set; }

        [StringLength(50)]
        public string RequestActionTypeName { get; set; }

        [StringLength(255)]
        public string RequestActionTypeDescription { get; set; }

        [StringLength(7)]
        public string BackgroundColor { get; set; }

        [StringLength(7)]
        public string TextColor { get; set; }

        public bool ChangeRequestStatusFlag { get; set; }

        public bool ReassignRequestFlag { get; set; }

        public bool AllowReplicationFlag { get; set; }

        public bool AllowUpdateOfServiceTypeFlag { get; set; }

        public bool AllowUpdateOfRequestFolioFlag { get; set; }

        public bool ByPassClientSideValidationFlag { get; set; }

        public bool DisplayFlag { get; set; }

        public bool UploadDocumentFlag { get; set; }

        public bool SystemReservedFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestActionTypeCustomField> RequestActionTypeCustomFields { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeRequestActionTypeLink> ServiceTypeRequestActionTypeLinks { get; set; }
    }
}

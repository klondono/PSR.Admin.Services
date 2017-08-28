using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PublicServiceRequest.Admin.BLL.Models
{
    public class BaseModelBLL
    {
        [StringLength(1)]
        public string AdmIsActive { get; set; }

        public Guid? AdmUserAdded { get; set; }

        [StringLength(100)]
        public string AdmUserAddedFullName { get; set; }

        public DateTime? AdmDateAdded { get; set; }

        public Guid? AdmUserModified { get; set; }

        [StringLength(100)]
        public string AdmUserModifiedFullName { get; set; }

        public DateTime? AdmDateModified { get; set; }

        [StringLength(64)]
        public string AdmUserAddedDomainName { get; set; }

        [StringLength(64)]
        public string AdmUserModifiedDomainName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServiceRequest.Admin.BLL.ErrorModel
{
    public class PSRAdminException : Exception
    {
        public PSRAdminException(string message) : base(message)
        {
        }
    }
}

namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class RequestOriginBLL : BaseModelBLL
    {
        private readonly IRequestOriginsRepository _requestOriginsRepository;
        public RequestOriginBLL(IRequestOriginsRepository requestOriginsRepository)
        {
            if (requestOriginsRepository != null)
            {
                _requestOriginsRepository = requestOriginsRepository;
            }
            else
            {
                throw new ArgumentNullException("IRequestOriginsRepository is null.");
            }
        }
        public int RequestOriginID { get; set; }

        [StringLength(50)]
        public string RequestOriginName { get; set; }

        [StringLength(255)]
        public string RequestOriginDescription { get; set; }

        [StringLength(1000)]
        public string AutoSelectedForActiveDirectoryGroup { get; set; }

        public bool? ForceAutoSelectedOriginFlag { get; set; }

        public bool? DisableProgressNotificationForAutoSelectedGroupFlag { get; set; }

        public IQueryable<RequestOrigin> GetRequestOrigins()
        {
            return _requestOriginsRepository.Get();
        }

        public IQueryable<RequestOrigin> Find(int? key)
        {
            return _requestOriginsRepository.Find(key);
        }

    }
}

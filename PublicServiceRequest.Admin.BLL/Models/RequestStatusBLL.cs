namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class RequestStatusBLL: BaseModelBLL
    {
        private readonly IRequestStatusesRepository _requestStatusesRepository;
        public RequestStatusBLL(IRequestStatusesRepository requestStatusesRepository)
        {
            if (requestStatusesRepository != null)
            {
                _requestStatusesRepository = requestStatusesRepository;
            }
            else
            {
                throw new ArgumentNullException("IRequestStatusesRepository is null.");
            }
        }

        public int RequestStatusID { get; set; }

        [StringLength(50)]
        public string RequestStatusName { get; set; }

        [StringLength(500)]
        public string RequestStatusDescription { get; set; }

        [StringLength(20)]
        public string RequestStatusColor { get; set; }

        public bool? StatusReopensRequestFlag { get; set; }

        public bool? StatusClosesRequestFlag { get; set; }

        public bool? SelectableOnRequestStatusChangeListFlag { get; set; }

        public bool? SystemReservedFlag { get; set; }


        public IQueryable<RequestStatus> GetRequestStatuses()
        {
            return _requestStatusesRepository.Get();
        }

        public IQueryable<RequestStatus> Find(int? key)
        {
            return _requestStatusesRepository.Find(key);
        }
    }
}

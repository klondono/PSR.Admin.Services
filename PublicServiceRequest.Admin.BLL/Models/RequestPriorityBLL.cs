namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class RequestPriorityBLL : BaseModelBLL
    {
        private readonly IRequestPrioritiesRepository _requestPrioritiesRepository;
        public RequestPriorityBLL(IRequestPrioritiesRepository requestPrioritiesRepository)
        {
            if (requestPrioritiesRepository != null)
            {
                _requestPrioritiesRepository = requestPrioritiesRepository;
            }
            else
            {
                throw new ArgumentNullException("IRequestPrioritiesRepository is null.");
            }
        }
        public int RequestPriorityID { get; set; }

        [StringLength(50)]
        public string RequestPriorityName { get; set; }

        [StringLength(255)]
        public string RequestPriorityDescription { get; set; }

        public IQueryable<RequestPriority> GetRequestPriorities()
        {
            return _requestPrioritiesRepository.Get();
        }

        public IQueryable<RequestPriority> Find(int? key)
        {
            return _requestPrioritiesRepository.Find(key);
        }

    }
}

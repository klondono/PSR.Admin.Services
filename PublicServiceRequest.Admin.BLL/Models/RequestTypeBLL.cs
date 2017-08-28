namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class RequestTypeBLL : BaseModelBLL
    {
        private readonly IRequestTypesRepository _requestTypeRepository;
        public RequestTypeBLL(IRequestTypesRepository requestTypesRepository)
        {
            if (requestTypesRepository != null)
            {
                _requestTypeRepository = requestTypesRepository;
            }
            else
            {
                throw new ArgumentNullException("IRequestTypesRepository is null.");
            }
        }
        public int RequestTypeID { get; set; }

        [StringLength(50)]
        public string RequestTypeName { get; set; }

        [StringLength(255)]
        public string RequestTypeDescription { get; set; }

        public IQueryable<RequestType> GetRequestTypes()
        {
            return _requestTypeRepository.Get();
        }

        public IQueryable<RequestType> Find(int? key)
        {
            return _requestTypeRepository.Find(key);
        }
    }
}

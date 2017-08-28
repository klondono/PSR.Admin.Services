namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class RequestFolioTypeBLL : BaseModelBLL
    {
        private readonly IRequestFolioTypesRepository _requestFolioTypesRepository;
        public RequestFolioTypeBLL(IRequestFolioTypesRepository requestFolioTypesRepository)
        {
            if (requestFolioTypesRepository != null)
            {
                _requestFolioTypesRepository = requestFolioTypesRepository;
            }
            else
            {
                throw new ArgumentNullException("IRequestFolioTypesRepository is null.");
            }
        }
        public int RequestFolioTypeID { get; set; }

        [StringLength(50)]
        public string RequestFolioTypeName { get; set; }

        [StringLength(255)]
        public string RequestFoliotypeDescription { get; set; }

        public IQueryable<RequestFolioType> GetRequestFolioTypes()
        {
            return _requestFolioTypesRepository.Get();
        }

        public IQueryable<RequestFolioType> Find(int? key)
        {
            return _requestFolioTypesRepository.Find(key);
        }

    }
}

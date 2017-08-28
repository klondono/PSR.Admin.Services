namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class ApplicationSourceBLL : BaseModelBLL
    {
        private readonly IApplicationSourcesRepository _applicationSourceRepository;
        public ApplicationSourceBLL(IApplicationSourcesRepository applicationSourcesRepository)
        {
            if (applicationSourcesRepository != null)
            {
                _applicationSourceRepository = applicationSourcesRepository;
            }
            else
            {
                throw new ArgumentNullException("IApplicationSourcesRepository is null.");
            }
        }
        public int ApplicationSourceID { get; set; }

        [StringLength(100)]
        public string ApplicationSourceName { get; set; }

        public IQueryable<ApplicationSource> GetApplicationSources()
        {
            return _applicationSourceRepository.Get();
        }

        public IQueryable<ApplicationSource> Find(int? key)
        {
            return _applicationSourceRepository.Find(key);
        }

    }
}

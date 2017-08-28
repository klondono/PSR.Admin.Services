namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class ServiceTypeChildStartTriggerBLL : BaseModelBLL
    {
        private readonly IServiceTypeChildStartTriggersRepository _serviceTypeChildStartTriggerRepository;
        public ServiceTypeChildStartTriggerBLL(IServiceTypeChildStartTriggersRepository serviceTypeChildStartTriggersRepository)
        {
            if (serviceTypeChildStartTriggersRepository != null)
            {
                _serviceTypeChildStartTriggerRepository = serviceTypeChildStartTriggersRepository;
            }
            else
            {
                throw new ArgumentNullException("IServiceTypeChildStartTriggersRepository is null.");
            }
        }

        public int ServiceTypeChildStartTriggerID { get; set; }

        [StringLength(25)]
        public string ServiceTypeChildStartTriggerName { get; set; }

        public virtual ICollection<ServiceTypeRelationshipDefinition> ServiceTypeRelationshipDefinitions { get; set; }

        public IQueryable<ServiceTypeChildStartTrigger> GetServiceTypeChildStartTriggers()
        {
            return _serviceTypeChildStartTriggerRepository.Get();
        }

        public IQueryable<ServiceTypeChildStartTrigger> Find(int? key)
        {
            return _serviceTypeChildStartTriggerRepository.Find(key);
        }
    }
}

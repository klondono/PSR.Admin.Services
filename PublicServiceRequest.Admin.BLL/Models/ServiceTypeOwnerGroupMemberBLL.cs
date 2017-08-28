namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class ServiceTypeOwnerGroupMemberBLL : BaseModelBLL
    {
        private readonly IServiceTypeOwnerGroupMembersRepository _serviceTypeOwnerGroupMemberRepository;
        public ServiceTypeOwnerGroupMemberBLL(IServiceTypeOwnerGroupMembersRepository serviceTypeOwnerGroupMembersRepository)
        {
            if (serviceTypeOwnerGroupMembersRepository != null)
            {
                _serviceTypeOwnerGroupMemberRepository = serviceTypeOwnerGroupMembersRepository;
            }
            else
            {
                throw new ArgumentNullException("IServiceTypeOwnerGroupMembersRepository is null.");
            }
        }
        public int ServiceTypeOwnerGroupMemberID { get; set; }

        public int? ServiceTypeOwnerGroupID { get; set; }

        public int? MemberID { get; set; }

        public IQueryable<ServiceTypeOwnerGroupMember> GetServiceTypeOwnerGroupMembers()
        {
            return _serviceTypeOwnerGroupMemberRepository.Get();
        }

        public IQueryable<ServiceTypeOwnerGroupMember> Find(int? key)
        {
            return _serviceTypeOwnerGroupMemberRepository.Find(key);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PublicServiceRequest.Admin.DAL.Models;
using PublicServiceRequest.Admin.BLL.Repositories.Interface;
using PublicServiceRequest.Admin.Common.Models;

namespace PublicServiceRequest.Admin.DAL.Repositories.Implementation
{
    public class ServiceTypeSearchKeywordLinksRepository : IServiceTypeSearchKeywordLinksRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<ServiceTypeSearchKeywordLink> Get()
        {
            return db.ServiceTypeSearchKeywordLinks;
        }

        public IQueryable<ServiceTypeSearchKeywordLink> Find(int? key)
        {
            return db.ServiceTypeSearchKeywordLinks.Where(serviceTypeSearchKeywordLink => serviceTypeSearchKeywordLink.ServiceTypeSearchKeywordLinkID == key);
        }

    }
}
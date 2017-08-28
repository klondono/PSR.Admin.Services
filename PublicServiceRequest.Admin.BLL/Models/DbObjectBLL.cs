namespace PublicServiceRequest.Admin.BLL.Models
{
    using Common.Models;
    using ErrorModel;
    using Repositories.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.OData;

    public partial class DbObjectBLL
    {
        private readonly IDbObjectsRepository _dbObjectsRepository;
        public DbObjectBLL(IDbObjectsRepository dbObjectsRepository)
        {
            if (dbObjectsRepository != null)
            {
                _dbObjectsRepository = dbObjectsRepository;
            }
            else
            {
                throw new ArgumentNullException("IDbObjectsRepository is null.");
            }
        }
        public IQueryable<DbObject> GetDbObjects()
        {
            return _dbObjectsRepository.Get();
        }

        public DbObject Find(int? key)
        {
            return _dbObjectsRepository.Find(key);
        }
    }
}

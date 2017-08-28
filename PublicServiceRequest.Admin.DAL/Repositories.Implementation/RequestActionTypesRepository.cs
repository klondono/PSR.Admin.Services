using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PublicServiceRequest.Admin.DAL.Models;
using PublicServiceRequest.Admin.BLL.Repositories.Interface;
using PublicServiceRequest.Admin.Common.Models;
using PublicServiceRequest.Admin.BLL.ErrorModel;

namespace PublicServiceRequest.Admin.DAL.Repositories.Implementation
{
    public class RequestActionTypesRepository : IRequestActionTypesRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<RequestActionType> Get()
        {
            return db.RequestActionTypes;
        }

        public RequestActionType Find(int? key)
        {
            if (key == 0)
            {
                return new RequestActionType();
            }
            return db.RequestActionTypes.Where(requestActionType => requestActionType.RequestActionTypeID == key).FirstOrDefault();
        }

        public int Create(RequestActionType requestActionType)
        {

            try
            {
                db.RequestActionTypes.Add(requestActionType);
                db.SaveChanges();
                return requestActionType.RequestActionTypeID;
            }
            catch (PSRAdminException ex)
            {
                throw new PSRAdminException("Error in RequestActionTypesRepository Creation: " + ex.ToString());
            }
        }

        public void SavePatch()
        {
            try
            {
                db.SaveChanges();
            }
            catch (PSRAdminException ex)
            {
                throw new PSRAdminException("Error on RequestActionTypesRepository Patch: " + ex.ToString());
            }
        }

        public void Delete(RequestActionType requestActionType)
        {
            db.RequestActionTypes.Remove(requestActionType);
            db.SaveChanges();
        }

    }
}

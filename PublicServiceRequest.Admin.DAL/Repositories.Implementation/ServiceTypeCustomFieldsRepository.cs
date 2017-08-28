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
    public class ServiceTypeCustomFieldsRepository : IServiceTypeCustomFieldsRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<ServiceTypeCustomField> Get()
        {
            return db.ServiceTypeCustomFields;
        }

        public ServiceTypeCustomField Find(int? key)
        {
            if (key == 0)
            {
                return new ServiceTypeCustomField();
            }
            return db.ServiceTypeCustomFields.Where(serviceTypeCustomField => serviceTypeCustomField.ServiceTypeCustomFieldID == key).FirstOrDefault();
        }

        public int Create(ServiceTypeCustomField serviceTypeCustomField) {

            try
            {
                db.ServiceTypeCustomFields.Add(serviceTypeCustomField);
                db.SaveChanges();
                return serviceTypeCustomField.ServiceTypeCustomFieldID;
            }
            catch (PSRAdminException ex)
            {
                throw new PSRAdminException("Error in ServiceTypeCustomFieldsRepository Creation: " + ex.ToString());
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
                throw new PSRAdminException("Error on ServiceTypeCustomFieldsRepository Patch: " + ex.ToString());
            }
        }

        public void Delete(ServiceTypeCustomField serviceTypeCustomField)
        {
            db.ServiceTypeCustomFields.Remove(serviceTypeCustomField);
            db.SaveChanges();
        }

        public bool InputSequenceExists(ServiceTypeCustomField serviceTypeCustomField)
        {
            return db.ServiceTypeCustomFields.
                Where(x => x.AdmIsActive != "N" && x.ServiceTypeID == serviceTypeCustomField.ServiceTypeID && x.InputSequence == serviceTypeCustomField.InputSequence && x.ServiceTypeCustomFieldID != serviceTypeCustomField.ServiceTypeCustomFieldID).
                Any();
        }

    }
}

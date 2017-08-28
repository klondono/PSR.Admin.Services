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
    public class RequestActionTypeCustomFieldsRepository : IRequestActionTypeCustomFieldsRepository
    {
        private PAGeneralDb db = new PAGeneralDb();

        public IQueryable<RequestActionTypeCustomField> Get()
        {
            return db.RequestActionTypeCustomFields;
        }

        public RequestActionTypeCustomField Find(int? key)
        {
            if (key == 0)
            {
                return new RequestActionTypeCustomField();
            }
            return db.RequestActionTypeCustomFields.Where(requestActionTypeCustomField => requestActionTypeCustomField.RequestActionTypeCustomFieldID == key).FirstOrDefault();
        }

        public int Create(RequestActionTypeCustomField actionTypeCustomField)
        {

            try
            {
                db.RequestActionTypeCustomFields.Add(actionTypeCustomField);
                db.SaveChanges();
                return actionTypeCustomField.RequestActionTypeCustomFieldID;
            }
            catch (PSRAdminException ex)
            {
                throw new PSRAdminException("Error in RequestActionTypeCustomFieldsRepository Creation: " + ex.ToString());
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
                throw new PSRAdminException("Error on RequestActionTypeCustomFieldsRepository Patch: " + ex.ToString());
            }
        }

        public void Delete(RequestActionTypeCustomField actionTypeCustomField)
        {
            db.RequestActionTypeCustomFields.Remove(actionTypeCustomField);
            db.SaveChanges();
        }

        public bool InputSequenceExists(RequestActionTypeCustomField actionTypeCustomField)
        {
            return db.RequestActionTypeCustomFields.
                Where(x => x.AdmIsActive != "N" && x.RequestActionTypeID == actionTypeCustomField.RequestActionTypeID && x.InputSequence == actionTypeCustomField.InputSequence && x.RequestActionTypeCustomFieldID != actionTypeCustomField.RequestActionTypeCustomFieldID).
                Any();
        }
    }
}

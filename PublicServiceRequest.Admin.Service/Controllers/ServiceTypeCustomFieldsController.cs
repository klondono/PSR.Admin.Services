using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using PublicServiceRequest.Admin.BLL.Models;
using PublicServiceRequest.Admin.DAL.Models;
using PublicServiceRequest.Admin.Common.Models;
using PublicServiceRequest.Admin.BLL.ErrorModel;

namespace PublicServiceRequest.Admin.Service.Controllers
{
    public class ServiceTypeCustomFieldsController : BaseODataController
    {
        private readonly ServiceTypeCustomFieldBLL _serviceTypeCustomFieldBLL;
        public ServiceTypeCustomFieldsController(ServiceTypeCustomFieldBLL serviceTypeCustomFieldBLL)
        {
            if (serviceTypeCustomFieldBLL != null)
            {
                _serviceTypeCustomFieldBLL = serviceTypeCustomFieldBLL;
            }
            else
            {
                throw new ArgumentNullException("ServiceTypeCustomFieldBLL is null.");
            }
        }

        // GET: odata/ServiceTypeCustomFields
        [EnableQuery(MaxExpansionDepth = 5)]
        public IHttpActionResult GetServiceTypeCustomFields()
        {
            return Ok(_serviceTypeCustomFieldBLL.GetServiceTypeCustomFields());
        }

        // GET: odata/ServiceTypeCustomFields(5)
        [EnableQuery]
        public IHttpActionResult GetServiceTypeCustomField([FromODataUri] int? key)
        {
            return Ok(_serviceTypeCustomFieldBLL.Find(key));
        }

        // POST: odata/ServiceTypeCustomFields
        public IHttpActionResult Post(ServiceTypeCustomField serviceTypeCustomField)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int serviceTypeCustomFieldID = -1;
            try
            {
                serviceTypeCustomFieldID = _serviceTypeCustomFieldBLL.Create(serviceTypeCustomField);
            }
            catch (PSRAdminException e)
            {
                throw new HttpResponseException(this.CreateHttpResponseMessage(e));
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok(serviceTypeCustomFieldID);
        }

        // PUT: odata/ServiceTypeCustomFields(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int? key, Delta<ServiceTypeCustomField> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _serviceTypeCustomFieldBLL.Patch(key, delta);
            }
            catch (PSRAdminException e)
            {
                throw new HttpResponseException(this.CreateHttpResponseMessage(e));
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok(key);
        }

        // DELETE: odata/ServiceTypeCustomFields(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {

            try
            {
                _serviceTypeCustomFieldBLL.Delete(key);
            }
            catch (PSRAdminException e)
            {
                throw new HttpResponseException(this.CreateHttpResponseMessage(e));
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok($"Service type custom field with id:{key} was deleted succesfully.");
        }


        //    // GET: odata/CommentsByPAFile(5)
        //    //[EnableQuery]
        //    //[ODataRoute("CommentsByPAFile(paFile={paFile})")]
        //    //[HttpGet]
        //    //public IQueryable<Comment> GetCommentsByPAFile([FromODataUri] string paFile)
        //    //{
        //    //    return _serviceTypesRepository.Get();
        //    //}

        //    // PUT: odata/Comments(5)
        //    public IHttpActionResult Put([FromODataUri] int? key, Delta<Comment> patch)
        //    {
        //        Validate(patch.GetEntity());

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        Comment Comment = _serviceTypesRepository.Find(key).SingleOrDefault();
        //        if (Comment == null)
        //        {
        //            return NotFound();
        //        }

        //        patch.Put(Comment);

        //        try
        //        {
        //            _serviceTypesRepository.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CommentExists(key))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return Updated(Comment);
        //    }

        //    // POST: odata/Comments
        //    public IHttpActionResult Post(Comment Comment)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        _serviceTypesRepository.Add(Comment);

        //        try
        //        {
        //            _serviceTypesRepository.SaveChanges();
        //        }
        //        catch (DbUpdateException)
        //        {
        //            if (ServiceTypeExists(Comment.CommID))
        //            {
        //                return Conflict();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return Created(Comment);
        //    }

        //    // PATCH: odata/Comments(5)
        //    [AcceptVerbs("PATCH", "MERGE")]
        //    public IHttpActionResult Patch([FromODataUri] long key, Delta<Comment> patch)
        //    {
        //        Validate(patch.GetEntity());

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        Comment Comment = _serviceTypesRepository.Find(key).SingleOrDefault();
        //        if (Comment == null)
        //        {
        //            return NotFound();
        //        }

        //        patch.Patch(Comment);

        //        try
        //        {
        //            _serviceTypesRepository.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ServiceTypeExists(key))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return Updated(Comment);
        //    }

        //    // DELETE: odata/Comments(5)
        //    public IHttpActionResult Delete([FromODataUri] int? key)
        //    {
        //        Comment Comment = _serviceTypesRepository.Find(key).SingleOrDefault();
        //        if (Comment == null)
        //        {
        //            return NotFound();
        //        }

        //        _serviceTypesRepository.Remove(Comment);
        //        _serviceTypesRepository.SaveChanges();

        //        return StatusCode(HttpStatusCode.NoContent);
        //    }

        //    private bool ServiceTypeExists(long key)
        //    {
        //        return _serviceTypesRepository.Count(e => e.CommID == key) > 0;
        //    }
    }
}
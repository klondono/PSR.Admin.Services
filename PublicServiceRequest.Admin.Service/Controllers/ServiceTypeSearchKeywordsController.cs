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
    public class ServiceTypeSearchKeywordsController : BaseODataController
    {
        private readonly ServiceTypeSearchKeywordBLL _serviceTypeSearchKeywordBLL;
        public ServiceTypeSearchKeywordsController(ServiceTypeSearchKeywordBLL serviceTypeSearchKeywordBLL)
        {
            if (serviceTypeSearchKeywordBLL != null)
            {
                _serviceTypeSearchKeywordBLL = serviceTypeSearchKeywordBLL;
            }
            else
            {
                throw new ArgumentNullException("ServiceTypeOwnerGroupBLL is null.");
            }
        }

        // GET: odata/ServiceTypeSearchKeywords
        [EnableQuery(MaxExpansionDepth = 5)]
        public IQueryable<ServiceTypeSearchKeyword> GetServiceTypeSearchKeywords()
        {
            return _serviceTypeSearchKeywordBLL.GetServiceTypeSearchKeywords();
        }

        // GET: odata/ServiceTypeSearchKeywords(5)
        [EnableQuery]
        public SingleResult<ServiceTypeSearchKeyword> GetServiceTypeSearchKeyword([FromODataUri] int? key)
        {
            return SingleResult.Create(_serviceTypeSearchKeywordBLL.Find(key));
        }

        [HttpPost]
        [EnableQuery(MaxExpansionDepth = 5)]
        // POST: /ServiceTypeSearchKeywords/PSR.AddOrUpdate
        public IHttpActionResult AddOrUpdate(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<ServiceTypeSearchKeywordLinkModel> returnedEntity = null;
            ServiceTypeSearchKeywordContainerModel containerModel = (ServiceTypeSearchKeywordContainerModel)parameters["serviceTypeSearchKeywordContainerModel"];

            try
            {
                returnedEntity = _serviceTypeSearchKeywordBLL.UpdateKeywordsForServiceType(containerModel);
            }
            catch (PSRAdminException ex)
            {
                throw new PSRAdminException("Error: " + ex.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok(returnedEntity);
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
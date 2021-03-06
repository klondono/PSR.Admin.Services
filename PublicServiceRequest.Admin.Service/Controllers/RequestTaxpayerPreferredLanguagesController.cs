﻿using System;
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

namespace PublicServiceRequest.Admin.Service.Controllers
{
    public class RequestTaxpayerPreferredLanguagesController : BaseODataController
    {
        private readonly RequestTaxpayerPreferredLanguageBLL _requestTaxpayerPreferredLanguageBLL;
        public RequestTaxpayerPreferredLanguagesController(RequestTaxpayerPreferredLanguageBLL requestTaxpayerPreferredLanguageBLL)
        {
            if (requestTaxpayerPreferredLanguageBLL != null)
            {
                _requestTaxpayerPreferredLanguageBLL = requestTaxpayerPreferredLanguageBLL;
            }
            else
            {
                throw new ArgumentNullException("RequestTaxpayerPreferredLanguageBLL is null.");
            }
        }

        // GET: odata/RequestTaxpayerPreferredLanguages
        [EnableQuery(MaxExpansionDepth = 5)]
        public IQueryable<RequestTaxpayerPreferredLanguage> GetRequestTaxpayerPreferredLanguages()
        {
            return _requestTaxpayerPreferredLanguageBLL.GetRequestTaxpayerPreferredLanguages();
        }

        // GET: odata/RequestTaxpayerPreferredLanguages(5)
        [EnableQuery]
        public SingleResult<RequestTaxpayerPreferredLanguage> GetRequestTaxpayerPreferredLanguage([FromODataUri] int? key)
        {
            return SingleResult.Create(_requestTaxpayerPreferredLanguageBLL.Find(key));
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
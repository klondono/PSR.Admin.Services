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
    public class ServiceTypesController : BaseODataController
    {
        private readonly ServiceTypeBLL _serviceTypeBLL;


        private PAGeneralDb db = new PAGeneralDb();

        public ServiceTypesController(ServiceTypeBLL serviceTypeBLL)
        {
            if (serviceTypeBLL != null)
            {
                _serviceTypeBLL = serviceTypeBLL;
            }
            else
            {
                throw new PSRAdminException("ServiceTypeBLL is null.");
            }
        }

        // GET: odata/ServiceTypes
        [EnableQuery(MaxExpansionDepth = 5)]
        public IHttpActionResult GetServiceTypes()
        {
            return Ok(_serviceTypeBLL.GetServiceTypes());
        }

        // GET: odata/ServiceTypes(5)
        public IHttpActionResult GetServiceType([FromODataUri] int? key)
        {
            return Ok(_serviceTypeBLL.Find(key));
        }

        // POST: odata/ServiceTypes
        public IHttpActionResult Post(ServiceType serviceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int serviceTypeID = -1;
            try
            {
                serviceTypeID = _serviceTypeBLL.Create(serviceType);
            }
            catch (PSRAdminException e)
            {
                throw new HttpResponseException(this.CreateHttpResponseMessage(e));
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok(serviceTypeID);
        }


        [HttpPost]
        // POST: /ServiceTypes/PSR.Clone
        [EnableQuery(MaxExpansionDepth = 5)]
        public IHttpActionResult Clone(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int newServiceTypeID = 0;
            int serviceTypeID = (int)parameters["serviceTypeID"];

            try
            {
                newServiceTypeID = _serviceTypeBLL.Clone(serviceTypeID);
            }
            catch (PSRAdminException e)
            {
                throw new HttpResponseException(this.CreateHttpResponseMessage(e));
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok(newServiceTypeID);
        }

        // PUT: odata/ServiceTypes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int? key, Delta<ServiceType> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _serviceTypeBLL.Patch(key, delta);
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

        //    // DELETE: odata/Comments(5)
        //public IHttpActionResult Delete([FromODataUri] int? key)
        //{
        //    Comment Comment = _serviceTypesRepository.Find(key).SingleOrDefault();
        //    if (Comment == null)
        //    {
        //        return NotFound();
        //    }

        //    _serviceTypesRepository.Remove(Comment);
        //    _serviceTypesRepository.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //    private bool ServiceTypeExists(long key)
        //    {
        //        return _serviceTypesRepository.Count(e => e.CommID == key) > 0;
        //    }
    }
}
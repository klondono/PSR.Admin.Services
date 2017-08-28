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
using System.Data.SqlClient;

namespace PublicServiceRequest.Admin.Service.Controllers
{
    public class ServiceTypeRelationshipDefinitionsController : BaseODataController
    {
        private readonly ServiceTypeRelationshipDefinitionBLL _serviceTypeRelationshipDefinitionBLL;
        public ServiceTypeRelationshipDefinitionsController(ServiceTypeRelationshipDefinitionBLL serviceTypeRelationshipDefinitionBLL)
        {
            if (serviceTypeRelationshipDefinitionBLL != null)
            {
                _serviceTypeRelationshipDefinitionBLL = serviceTypeRelationshipDefinitionBLL;
            }
            else
            {
                throw new ArgumentNullException("ServiceTypeRelationshipDefinitionBLL is null.");
            }
        }

        // GET: PSRAdminService/ServiceTypeRelationshipDefinitions
        [EnableQuery(MaxExpansionDepth = 5)]
        public IHttpActionResult GetServiceTypeRelationshipDefinitions()
        {
            return Ok(_serviceTypeRelationshipDefinitionBLL.GetServiceTypeRelationshipDefinitions());
        }

        // GET: PSRAdminService/ServiceTypeRelationshipDefinitions(5)
        [EnableQuery]
        public IHttpActionResult GetServiceTypeRelationshipDefinition([FromODataUri] int? key)
        {
            return Ok(_serviceTypeRelationshipDefinitionBLL.Find(key));
        }

        // POST: PSRAdminService/ServiceTypeRelationshipDefinitions
        public IHttpActionResult Post(ServiceTypeRelationshipDefinition serviceTypeCustomField)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeRelationshipDefinition serviceTypeRelationship = null;

            try
            {
                serviceTypeRelationship = _serviceTypeRelationshipDefinitionBLL.Create(serviceTypeCustomField);
            }
            catch (PSRAdminException e)
            {
                throw new HttpResponseException(this.CreateHttpResponseMessage(e));
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok(serviceTypeRelationship);
        }

        // PUT: PSRAdminService/ServiceTypeRelationshipDefinitions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int? key, Delta<ServiceTypeRelationshipDefinition> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeRelationshipDefinition serviceTypeRelationship = null;

            try
            {
                serviceTypeRelationship = _serviceTypeRelationshipDefinitionBLL.Patch(key, delta);
            }
            catch (PSRAdminException e)
            {
                throw new HttpResponseException(this.CreateHttpResponseMessage(e));
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok(serviceTypeRelationship);
        }

        [HttpPost]
        // POST: /ServiceTypeRequestActionTypeLinks/PSR.AddOrUpdate
        [EnableQuery(MaxExpansionDepth = 5)]
        public IHttpActionResult DeleteRelationship(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeRelationshipDefinitionDeletionModel deletionModel = (ServiceTypeRelationshipDefinitionDeletionModel)parameters["serviceTypeRelationshipDefinitionDeletionModel"];

            try
            {
                _serviceTypeRelationshipDefinitionBLL.Delete(deletionModel);
            }
            catch (PSRAdminException e)
            {
                throw new HttpResponseException(this.CreateHttpResponseMessage(e));
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok("Successfully deleted Service Type relationship(s).");
        }
    }
}
using CredMgrService.DbOperations.Repository;
using CredMgrService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CredMgrService.Controllers
{
    public class MasterMappingController : ApiController
    {
        private MasterMappingRepository _mapping = null;

        public MasterMappingController()
        {
            _mapping = new MasterMappingRepository();
        }

        [HttpPost]
        public HttpResponseMessage AddMapping(MasterMappingModel mappingModel)
        {

            var result = _mapping.AddMapping(mappingModel);

            if (result == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            else
             {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "Data Not Added");
             }

         }

    }

}

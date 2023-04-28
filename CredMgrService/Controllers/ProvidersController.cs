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
    public class ProvidersController : ApiController
    {
        private ProvidersRepository _providers = null;

        public ProvidersController()
        {
            _providers = new ProvidersRepository();
        }

        //public bool SaveProviders(ProvidersModel providersModel)
        //{
        //    bool result = false;
        //    result = _providers.AddProviders(providersModel);
        //    return result;
        //}


        //[HttpPut]
        //public HttpResponseMessage UpdateProviders(ProvidersModel providersModel)
        //{
        //    var result = _providers.UpdateProviders(providersModel);


        //    if (result == true)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }

        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "Data Not Updated");
        //    }
        //}


        [HttpPost]
        public HttpResponseMessage AddProviders(ProvidersModel providersModel)
        {
            if(providersModel.PK_Provider == 0)
            {

                try
                {
                    var result = _providers.AddProviders(providersModel);


                    if (result != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "Data Not Added");
                    }
                }
                catch (Exception ex)
                {
                    var result = "Error occured, contact administrator! " + ex.Message;

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }

            }

            else
            {
                var result = _providers.UpdateProviders(providersModel);


                if (result == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "Data Not Updated");
                }
            }
        }


        [HttpGet]
        public List<ProvidersModel> Get()
        {
            var result = _providers.GetProviders();
            return (result);

        }
        
        public IHttpActionResult Get(int id)
        {
            var result = _providers.GetProviders().Find(pmodel => pmodel.PK_Provider == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new{result});

        }

     

    }
}


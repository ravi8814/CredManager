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
    public class InsuranceController : ApiController
    {
        private InsuranceRepository _insurance = null;

        public InsuranceController()
        {
            _insurance = new InsuranceRepository();
        }

        [HttpPost]
        public HttpResponseMessage AddInsurance(InsuranceModel insuranceModel)
        {
            if(insuranceModel.PK_Insurance== 0)
            { 
            var result = _insurance.NewInsurance(insuranceModel);


            if (result == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "Data Not Added");
            }
            }

            else
            {
                var result = _insurance.UpdateInsurance(insuranceModel);


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
        public List<InsuranceModel> Get(int? id)
        {
            var result = _insurance.GetInsurance();
            return (result);

        }


        //[HttpGet]
        //public IHttpActionResult Get(int id)
        //{
        //    var result = _insurance.GetInsurance().Find(Imodel => Imodel.PK_Insurance == id);
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(new { result });

        //}

        //[HttpPut]
        //public HttpResponseMessage UpdateInsurance(InsuranceModel insuranceModel)
        //{
        //    var result = _insurance.UpdateInsurance(insuranceModel);


        //    if (result == true)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }

        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "Data Not Updated");
        //    }
        //}
    }
}

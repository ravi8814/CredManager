using CredMgr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Security;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CredMgr.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult State()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(@"GetState\GetState").Result;
            IEnumerable<StateViewModels> stateList;
            int statuscode = (int)response.StatusCode;

            if (statuscode == 200)
            {
                stateList = response.Content.ReadAsAsync<IList<StateViewModels>>().Result;

            }
            else

            {
                stateList = Enumerable.Empty<StateViewModels>();
            }

            return View(stateList);
        }

        [HttpPost]
        public ActionResult State(List<StateViewModels> svm)
        {
            return View();
        }


        public ActionResult Provider()
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(@"Providers").Result;

            IEnumerable<ProvidersModel> providerList;
            int statuscode = (int)response.StatusCode;

            if (statuscode == 200)
            {
                providerList = response.Content.ReadAsAsync<IList<ProvidersModel>>().Result;
            }
            else

            {
                providerList = Enumerable.Empty<ProvidersModel>();
            }


            return View(providerList);
        }



        [HttpPost]
        public ActionResult EditProvider(ProvidersModel providersModel)
        {
            if (providersModel.PK_Provider == 0)
            {
                var json = JsonConvert.SerializeObject(providersModel);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsync(@"Providers/AddProviders", stringContent).Result;
                //HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync(@"Providers\AddProviders", providersModel).Result;

                //HttpResponseMessage response1 = GlobalVariables.WebApiClient.PostAsJsonAsync("UserLogin", providersModel).Result;
                int statuscode = (int)response.StatusCode;


                if (statuscode == 200)
                {
                    ViewBag.Message = "Data Added";
                    ModelState.Clear();
                }
                else

                {
                    ViewBag.Message = "Data not Saved";
                    ModelState.Clear();
                }

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync(@"Providers\UpdateProviders", providersModel).Result;

                //HttpResponseMessage response1 = GlobalVariables.WebApiClient.PostAsJsonAsync("UserLogin", providersModel).Result;
                int statuscode = (int)response.StatusCode;

                if (statuscode == 200)
                {
                    ViewBag.Message = "Data Updated";
                }
                else

                {
                    ViewBag.Message = "Data not Updated";
                }

            }

            return View(providersModel);
        }

        public async Task<ActionResult> EditProvider(int? id)
        {

            ProvidersModel providerModel;
            if (id == null)
            {
                
                return View(new ProvidersModel());

            }

            else
            {   
                var response = await GlobalVariables.WebApiClient.GetAsync("Providers/"+ id.ToString());
                
                var UserResponse = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(UserResponse);

                var lstres = JsonConvert.DeserializeObject<object>(UserResponse);
                providerModel = JsonConvert.DeserializeObject<ProvidersModel>(jObject["result"].ToString());
               // providerModel = response.Content.ReadAsAsync<ProvidersModel>().Result;
                return View(providerModel);
            }

        }



        public ActionResult Insurance()
        {


            HttpResponseMessage responseState = GlobalVariables.WebApiClient.GetAsync(@"GetState\GetState").Result;
            HttpResponseMessage responseInsurance = GlobalVariables.WebApiClient.GetAsync(@"Providers").Result;

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(@"Insurance/Get").Result;

            InsuranceMappingVM insuranceMapping = new InsuranceMappingVM();
            int statuscode = (int)response.StatusCode;
            int statuscodeState = (int)responseState.StatusCode;
            int statuscodeProvider = (int)response.StatusCode;
            if (statuscode == 200 && statuscodeProvider == 200 && statuscodeState == 200)
            {
               insuranceMapping.Insurance = response.Content.ReadAsAsync<IList<InsuranceModel>>().Result;
                var stateList = responseState.Content.ReadAsAsync<IList<StateViewModels>>().Result;
                ViewBag.StateList = stateList;

                var providerList = responseInsurance.Content.ReadAsAsync<IList<ProvidersModel>>().Result;
                ViewBag.ProviderList = providerList;

            }
            else

            {
                insuranceMapping.Insurance = Enumerable.Empty<InsuranceModel>();
            }

            return View(insuranceMapping);
        }



        [HttpPost]
        public ActionResult Insurance(InsuranceMappingVM insuranceMapping)
        {
            //insuranceMapping.Selected_ProviderId = string.Join(",", insuranceMapping.Selected_ProviderArray);

            var json = JsonConvert.SerializeObject(insuranceMapping);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsync(@"MasterMapping/AddMapping", stringContent).Result;
          
            int statuscode = (int)response.StatusCode;


            if (statuscode == 200)
            {
                ViewBag.Message = "Data Added";
                ModelState.Clear();
                return Redirect("Insurance");
            }
            else

            {
                ViewBag.Message = "Data not Saved";
                ModelState.Clear();
            }

            return View(new InsuranceMappingVM());
        }



        public async Task<ActionResult> EditInsurance(int? id)
        {
            InsuranceModel insuranceModel;
            if (id == null)
            {
                var providerlist = new List<string>() { "HMO", "PPO" };
                ViewBag.list = providerlist;
                return View(new InsuranceModel());

            }

            else
            {
                var response = await GlobalVariables.WebApiClient.GetAsync("Insurance/" + id.ToString());

                var UserResponse = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(UserResponse);

                var lstres = JsonConvert.DeserializeObject<object>(UserResponse);
                insuranceModel = JsonConvert.DeserializeObject<InsuranceModel>(jObject["result"].ToString());
                // providerModel = response.Content.ReadAsAsync<ProvidersModel>().Result;
                return View(insuranceModel);
            }
        }


        [HttpPost]
        public ActionResult EditInsurance(InsuranceModel insuranceModel)
        {
            if (insuranceModel.PK_Insurance == 0)
            {
                
                var json = JsonConvert.SerializeObject(insuranceModel);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsync(@"Insurance/AddInsurance", stringContent).Result;
                //HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync(@"Providers\AddProviders", providersModel).Result;

                //HttpResponseMessage response1 = GlobalVariables.WebApiClient.PostAsJsonAsync("UserLogin", providersModel).Result;
                int statuscode = (int)response.StatusCode;


                if (statuscode == 200)
                {
                    ViewBag.Message = "Data Added";
                    ModelState.Clear();
                }
                else

                {
                    ViewBag.Message = "Data not Saved";
                    ModelState.Clear();
                }

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync(@"Insurance\UpdateInsurance", insuranceModel).Result;

                //HttpResponseMessage response1 = GlobalVariables.WebApiClient.PostAsJsonAsync("UserLogin", providersModel).Result;
                int statuscode = (int)response.StatusCode;

                if (statuscode == 200)
                {
                    ViewBag.Message = "Data Updated";
                }
                else

                {
                    ViewBag.Message = "Data not Updated";
                }

            }

            return View(insuranceModel);
        }


        [HttpGet]
        public ActionResult AddMasterMapping13()
        {

            InsuranceMappingVM mappingVM;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync(@"GetState\GetState").Result;
            HttpResponseMessage responseInsurance = GlobalVariables.WebApiClient.GetAsync(@"Providers").Result;

            int statuscode = (int)response.StatusCode;
            int statuscodeProvider = (int)response.StatusCode;

            if (statuscode == 200 && statuscodeProvider == 200)
            {

                var stateList = response.Content.ReadAsAsync<IList<StateViewModels>>().Result;
                ViewBag.StateList = stateList;

                var providerList = responseInsurance.Content.ReadAsAsync<IList<ProvidersModel>>().Result;
                ViewBag.ProviderList = providerList;


            }
            return View(new InsuranceMappingVM());

        }

       
    } 
}
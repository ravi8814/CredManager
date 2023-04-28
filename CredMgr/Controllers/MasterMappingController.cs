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
    public class MasterMappingController : Controller
    {
        // GET: MasterMapping
        public ActionResult Index()
        {
            return View();
        }
    }
}
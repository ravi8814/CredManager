using CredMgrService.DbOperations.Repository;
using CredMgrService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CredMgrService.Controllers
{
    public class UserLoginController : ApiController
    {
        private LoginRepository _login = null;


        public UserLoginController()
        {
            _login = new LoginRepository();
        }

        public HttpResponseMessage UserLogin(UserInfoesModel userInfoes)
        {
            var result = _login.ValidateUser(userInfoes);


            if (result == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "Invalid User Name or Password");
            }
        }

    }
}
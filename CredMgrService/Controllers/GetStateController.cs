
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

    public class GetStateController : ApiController
    {
        private GetStateRepository _states = null;


        public GetStateController()
        {
            _states = new GetStateRepository();
        }

        public IEnumerable<GetStateModel> GetState()
        {
            List<GetStateModel> tempResult = new List<GetStateModel>();
            tempResult = _states.GetState();

            return (tempResult.ToList());
        }

        [HttpPut]
        public bool SaveState(GetStateModel lstState)
        {
            bool result = false;
            if(lstState.PK_CompanyStates == 0)
            { 
            result = _states.SaveState(lstState);
            return result;
            }

            else
            {
                result = _states.DeleteState(lstState);
                return result;
            }
        }


    }
}

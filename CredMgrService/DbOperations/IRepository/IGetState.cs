using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CredMgrService.Models;

namespace CredMgrService.DbOperations.IRepository
{
    public interface IGetState
    {
        List<GetStateModel> GetState();
    }

    public interface ISaveState
    {
        bool SaveState(List<GetStateModel> lstState);
    }
}
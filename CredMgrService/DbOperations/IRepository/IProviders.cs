using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CredMgrService.Models;

namespace CredMgrService.DbOperations.IRepository
{
    public interface IProviders
    {
        string AddProviders(ProvidersModel providersModel);
    }
}
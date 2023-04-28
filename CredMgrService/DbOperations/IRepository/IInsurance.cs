using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CredMgrService.Models;

namespace CredMgrService.DbOperations.IRepository
{
    public interface IInsurance
    {
        bool NewInsurance(InsuranceModel insuranceModel);
    }
}
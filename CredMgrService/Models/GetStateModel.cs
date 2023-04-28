using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CredMgrService.Models
{
    public class GetStateModel
    {
        public int PK_States { get; set; }
        public int PK_CompanyStates { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public bool IsChecked { get; set; }

    }
}
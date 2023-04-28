using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CredMgr.Models
{
    public class StateViewModels
    {
        public int PK_States { get; set; }
        public int PK_CompanyStates { get; set; }
        public bool IsChecked { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }
}
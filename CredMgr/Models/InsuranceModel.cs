using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CredMgr.Models
{
    public class InsuranceModel
    {
        public int PK_Insurance { set; get; }
        public string InsuranceCode { set; get; }

        public string InsuranceName { set; get; }

        public string AddressLine1 { set; get; }

        public string AddressLine2 { set; get; }

        public string City { set; get; }
        public string State { set; get; }
        public string ZipCode { set; get; }

        public string PhoneNumber { set; get; }

        public string EmailId { set; get; }

        public string Website { set; get; }

        public string Note { set; get; }

        public string PayerID { set; get; }

        public string InsuranceType { set; get; }
    }
}
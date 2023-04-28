using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CredMgrService.Models
{
    public class ProvidersModel
    {

       
        public int PK_Provider { set; get; }
        public int CompanyId { set; get; }

        [Required(ErrorMessage = "Group Name")]
        public string GroupName { set; get; }

        [Required(ErrorMessage = "Group Tax-Id")]
        public string GroupTaxId { set; get; }

        [Required(ErrorMessage = "Group NPI")]
        public string GroupNPI { set; get; }

        [Required(ErrorMessage = "ProvCode")]
        public string ProvCode { set; get; }

        [Required(ErrorMessage = "ProvName")]
        public string ProvName { set; get; }

        [Required(ErrorMessage = "Title")]
        public string Title { set; get; }

        public string NPI { set; get; }

        public DateTime DOB { set; get; }

        public string SSN { set; get; }
        public string Speciality { set; get; }
        public string AddressLine1 { set; get; }

        public string AddressLine2 { set; get; }

        public string City { set; get; }
        public string State { set; get; }
        public string ZipCode { set; get; }
        public string HomePhoneNumber { set; get; }
        public string WorkPhoneNumber { set; get; }
        public string OtherPhoneNumber { set; get; }
        public string FaxNumber { set; get; }

        public string EmailId { set; get; }
        public string Note { set; get; }
        public string FlagId { set; get; }
    }
}
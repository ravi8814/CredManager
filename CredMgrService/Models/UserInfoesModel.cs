using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CredMgrService.Models
{
    public class UserInfoesModel
    {
        public int UserInfoes { set; get; }



        [Required(ErrorMessage = "Username Required")]
        public string loginName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string loginPwd { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Middle Name Required")]
        public string middleName { get; set; }


        [Required(ErrorMessage = "Email Id Required")]
        public string emailID { get; set; }


        [Required(ErrorMessage = "Mobile No Required")]
        public string mobileNo { get; set; }

        public DateTime createDate { get; set; }

        public DateTime modifiedDate { get; set; }

        public bool status { get; set; }

        public bool isAdmin { set; get; }

        public int companyId { set; get; }
    }
}
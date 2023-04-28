using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CredMgr.Models
{
    public class MasterMappingModel
    {
        public int PK_MasterId { set; get; }

        public int StateId { set; get; }

        public string Selected_ProviderId { set; get; }

        public string[] Selected_ProviderArray { set; get; }
        public aplicationMethod AplicationMethod { set; get; }

        public plansList Plans { set; get; }

        public participationStatus ParticipationStatus { set; get; }
        public webPortal WebPortal { set; get; }
        public edi EDI { set; get; }

        [DataType(DataType.Date)]
        public DateTime EffectiveStartDate { set; get; }

        [DataType(DataType.Date)]
        public DateTime EffectiveEndDate { set; get; }


        [DataType(DataType.Date)]
        public DateTime NextFollowUpDate { set; get; }

        public string Comment { set; get; }



        public enum aplicationMethod
        {
            Paper = 1,
            Online = 2
        }

        public enum plansList
        {
           Various =1
        }

        public enum participationStatus
        {
            PENDING =1,  
           INPROCESS =2, 
           COMPLETED=3,
           EXPIRED=4
        }

        public enum webPortal
        {
            Yes=1,
            No =2
        }


        public enum edi
        {
            Yes = 1,
            No = 2
        }
    }

}
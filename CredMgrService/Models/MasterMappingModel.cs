using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CredMgrService.Models
{
    public class MasterMappingModel
    {
        public IEnumerable<InsuranceModel> Insurance { get; set; }


        public int PK_MasterId { set; get; }

        public int StateId { set; get; }

        public string Selected_ProviderId { set; get; }

        public string[] Selected_ProviderArray { set; get; }
        public string AplicationMethod { set; get; }

        public string Plans { set; get; }

        public string ParticipationStatus { set; get; }
        public string WebPortal { set; get; }
        public string EDI { set; get; }

       
        public DateTime EffectiveStartDate { set; get; }

       
        public DateTime EffectiveEndDate { set; get; }


    
        public DateTime NextFollowUpDate { set; get; }

        public string Comment { set; get; }


        //public MasterMappingModel MappingModel { set; get; }





    }
}
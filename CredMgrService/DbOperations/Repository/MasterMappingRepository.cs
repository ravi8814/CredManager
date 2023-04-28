using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CredMgrService.DbOperations.IRepository;
using CredMgrService.Models;
using System.Data.SqlClient;
using System.Data;

namespace CredMgrService.DbOperations.Repository
{



    public class MasterMappingRepository
    {
        DbConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;


        public bool AddMapping(MasterMappingModel mappingModel)
        {

            if (mappingModel.AplicationMethod == "1")
            {
                mappingModel.AplicationMethod = "Paper";
            }

            else
            {
                mappingModel.AplicationMethod = "Online";
            }


            if (mappingModel.Plans == "1")
            {
                mappingModel.Plans = "Various";
            }

            else
            {
                mappingModel.Plans = "null";
            }


            if(mappingModel.ParticipationStatus == "1")
            {
                mappingModel.ParticipationStatus = "PENDING";
            }

            else if(mappingModel.ParticipationStatus=="2")
            {
                
                mappingModel.ParticipationStatus = "INPROCESS";
            }
            
            else if(mappingModel.ParticipationStatus == "3")
            {
                mappingModel.ParticipationStatus = "COMPLETED";
            }

            else
            {
                mappingModel.ParticipationStatus = "EXPIRED";
            }

           

            if(mappingModel.EDI== "1")
            {
                mappingModel.EDI = "Yes";
            }

            else
            {
                mappingModel.EDI = "No";
            }



            if(mappingModel.WebPortal == "1")
            {
                mappingModel.WebPortal = "Yes";
            }

            else
            {
                mappingModel.WebPortal = "No";
            }

            con = new DbConnection();
            cmd = new SqlCommand("Sp_MasterMapping", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateId", mappingModel.StateId);
            cmd.Parameters.AddWithValue("@SelectedProvidersId", mappingModel.Selected_ProviderId);
            cmd.Parameters.AddWithValue("@ApplicationMethod", mappingModel.AplicationMethod);
            cmd.Parameters.AddWithValue("@Plans", mappingModel.Plans);
            cmd.Parameters.AddWithValue("@ParticipationStatus", mappingModel.ParticipationStatus);
            cmd.Parameters.AddWithValue("@WebPortal", mappingModel.WebPortal);
            cmd.Parameters.AddWithValue("@EDI", mappingModel.EDI);
            cmd.Parameters.AddWithValue("@EffectiveStartDate", mappingModel.EffectiveStartDate);
            cmd.Parameters.AddWithValue("@EffectiveEndDate", mappingModel.EffectiveEndDate);
            cmd.Parameters.AddWithValue("@NextFollowUpDate", mappingModel.NextFollowUpDate);
            cmd.Parameters.AddWithValue("@Comments", mappingModel.Comment);
            cmd.Parameters.AddWithValue("@Flag_Id", "Insert");
            con.OpenConnection();
            bool status;

            if (cmd.ExecuteNonQuery() > 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            con.CloseConnection();
            return status;
        }
    }
}
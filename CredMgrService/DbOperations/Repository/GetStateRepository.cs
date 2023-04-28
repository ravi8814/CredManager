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
    public class GetStateRepository : IGetState
    {
        DbConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        bool status;
       
        public List<GetStateModel> GetState()
        {
            List<GetStateModel> lstGetState = new List<GetStateModel>();
            con = new DbConnection();
            cmd = new SqlCommand("GetStateMaster", con.GetConnection);           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CompanyID", "1"));
            cmd.Parameters.Add(new SqlParameter("@flag", "GetAllState"));
            con.OpenConnection();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                GetStateModel gs = new GetStateModel();
                gs.PK_States = Convert.ToInt32(dr["PK_States"].ToString());
                if (dr["PK_CompanyStates"] == null || dr["PK_CompanyStates"].ToString()=="")
                {
                    gs.PK_CompanyStates = 0;
                    gs.IsChecked = false;
                }
                else
                {
                    gs.PK_CompanyStates = Convert.ToInt32(dr["PK_CompanyStates"].ToString());
                    gs.IsChecked = true;
                }
                gs.code = dr["code"].ToString();
                gs.name = dr["name"].ToString();

                lstGetState.Add(gs);

            }
            con.CloseConnection();
            return lstGetState;

        }

        //public bool SaveState(List<GetStateModel> lstState)
        //{
        //    int result = 0;
        //   //ist<GetStateModel> lstGetState = new List<GetStateModel>();
        //    con = new DbConnection();

        //    cmd = new SqlCommand("insert into tblLinkCompanyStates(CompanyID, StateID) values(1, 3)", con.GetConnection);
        //    //cmd = new SqlCommand("GetStateMaster", con.GetConnection);
        //    cmd.CommandType = CommandType.Text;
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.Parameters.Add(new SqlParameter("@CompanyID", "1"));
        //    //cmd.Parameters.Add(new SqlParameter("@flag", "GetAllState"));
        //    con.OpenConnection();
        //    result = cmd.ExecuteNonQuery();                  
        //    con.CloseConnection();
        //    if (result > 0)
        //        return true;
        //    else
        //        return false;
        //}

        public bool SaveState(GetStateModel state)
        {
            con = new DbConnection();
            cmd = new SqlCommand("GetStateMaster", con.GetConnection);           
            int result = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Insert");
            cmd.Parameters.AddWithValue("@CompanyID", 1);
            cmd.Parameters.AddWithValue("@StateId", state.PK_States);
            con.OpenConnection();
            result = cmd.ExecuteNonQuery();
            con.CloseConnection();
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool DeleteState(GetStateModel state)
        {
            con = new DbConnection();
            cmd = new SqlCommand("GetStateMaster", con.GetConnection);          
            int result = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Delete");
            cmd.Parameters.AddWithValue("@PK_CompanyStates", state.PK_CompanyStates);
            con.OpenConnection();
            result = cmd.ExecuteNonQuery();
            con.CloseConnection();
            if (result > 0)
                return true;
            else
                return false;
        }

    }
}
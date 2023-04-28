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
    public class InsuranceRepository : IInsurance
    {
        DbConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        public bool NewInsurance(InsuranceModel insuranceModel)
        {
            con = new DbConnection();
            cmd = new SqlCommand("Sp_Insurance", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InsuranceCode", insuranceModel.InsuranceCode);
            cmd.Parameters.AddWithValue("@InsuranceName", insuranceModel.InsuranceName);
            cmd.Parameters.AddWithValue("@AddressLine1", insuranceModel.AddressLine1);
            cmd.Parameters.AddWithValue("@AddressLine2", insuranceModel.AddressLine2);
            cmd.Parameters.AddWithValue("@City", insuranceModel.City);
            cmd.Parameters.AddWithValue("@State", insuranceModel.State);
            cmd.Parameters.AddWithValue("@ZipCode", insuranceModel.ZipCode);
            cmd.Parameters.AddWithValue("@PhoneNumber", insuranceModel.PhoneNumber);
            cmd.Parameters.AddWithValue("@EmailId", insuranceModel.EmailId);
            cmd.Parameters.AddWithValue("@Website", insuranceModel.Website);
            cmd.Parameters.AddWithValue("@Note", insuranceModel.Note);
            cmd.Parameters.AddWithValue("@PayerID", insuranceModel.PayerID);
            cmd.Parameters.AddWithValue("@InsuranceType", insuranceModel.InsuranceType);
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


        public List<InsuranceModel> GetInsurance()
        {
            List<InsuranceModel> Insurancelist = new List<InsuranceModel>();
            con = new DbConnection();
            cmd = new SqlCommand("Sp_Insurance", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Flag_Id", "GetAll");
            adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.OpenConnection();
            adpt.Fill(dt);
            con.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                Insurancelist.Add(
                    new InsuranceModel
                    {
                        PK_Insurance = Convert.ToInt32(dr["PK_Insurance"]),
                        InsuranceCode = Convert.ToString(dr["InsuranceCode"]),
                        InsuranceName = Convert.ToString(dr["InsuranceName"]),
                        AddressLine1 = Convert.ToString(dr["AddressLine1"]),
                        AddressLine2 = Convert.ToString(dr["AddressLine2"]),
                        City = Convert.ToString(dr["City"]),
                        State = Convert.ToString(dr["State"]),
                        ZipCode = Convert.ToString(dr["ZipCode"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        EmailId = Convert.ToString(dr["EmailId"]),
                        Note = Convert.ToString(dr["Note"]),
                        Website = Convert.ToString(dr["Website"]),
                        PayerID = Convert.ToString(dr["PayerID"]),
                        InsuranceType= Convert.ToString(dr["InsuranceType"])
                    });
            }

            return Insurancelist;


        }

        public bool UpdateInsurance(InsuranceModel insuranceModel)
        {
            con = new DbConnection();
            cmd = new SqlCommand("Sp_Insurance", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Flag_Id", "Update");
            cmd.Parameters.AddWithValue("@PK_Insurance", insuranceModel.PK_Insurance);
            cmd.Parameters.AddWithValue("@InsuranceCode", insuranceModel.InsuranceCode);
            cmd.Parameters.AddWithValue("@InsuranceName", insuranceModel.InsuranceName);
            cmd.Parameters.AddWithValue("@AddressLine1", insuranceModel.AddressLine1);
            cmd.Parameters.AddWithValue("@AddressLine2", insuranceModel.AddressLine2);
            cmd.Parameters.AddWithValue("@City", insuranceModel.City);
            cmd.Parameters.AddWithValue("@State", insuranceModel.State);
            cmd.Parameters.AddWithValue("@ZipCode", insuranceModel.ZipCode);
            cmd.Parameters.AddWithValue("@PhoneNumber", insuranceModel.PhoneNumber);
            cmd.Parameters.AddWithValue("@EmailId", insuranceModel.EmailId);
            cmd.Parameters.AddWithValue("@Website", insuranceModel.Website);
            cmd.Parameters.AddWithValue("@Note", insuranceModel.Note);
            cmd.Parameters.AddWithValue("@PayerID", insuranceModel.PayerID);
            cmd.Parameters.AddWithValue("@InsuranceType", insuranceModel.InsuranceType);

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
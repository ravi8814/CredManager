using CredMgrService.DbOperations.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CredMgrService.Models;
using System.Data.SqlClient;
using System.Data;

namespace CredMgrService.DbOperations.Repository
{
    public class ProvidersRepository : IProviders
    {
        DbConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;

        string query;
        public string AddProviders(ProvidersModel providersModel)
        {
            string result = null;
            con = new DbConnection();
            try
            {
                cmd = new SqlCommand("Sp_Providers", con.GetConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Flag_Id", "Insert");
                cmd.Parameters.AddWithValue("@CompanyId", providersModel.CompanyId);
                cmd.Parameters.AddWithValue("@GroupName", providersModel.GroupName);
                cmd.Parameters.AddWithValue("@GroupTaxId", providersModel.GroupTaxId);
                cmd.Parameters.AddWithValue("@GroupNPI", providersModel.GroupNPI);
                cmd.Parameters.AddWithValue("@ProvCode", providersModel.ProvCode);
                cmd.Parameters.AddWithValue("@ProvName", providersModel.ProvName);
                cmd.Parameters.AddWithValue("@Title", providersModel.Title);
                cmd.Parameters.AddWithValue("@NPI", providersModel.NPI);
                //cmd.Parameters.AddWithValue("@DOB", providersModel.DOB);
                cmd.Parameters.AddWithValue("@SSN", providersModel.SSN);
                cmd.Parameters.AddWithValue("@Speciality", providersModel.Speciality);
                cmd.Parameters.AddWithValue("@AddressLine1", providersModel.AddressLine1);
                cmd.Parameters.AddWithValue("@AddressLine2", providersModel.AddressLine2);
                cmd.Parameters.AddWithValue("@City", providersModel.City);
                cmd.Parameters.AddWithValue("@State", providersModel.State);
                cmd.Parameters.AddWithValue("@ZipCode", providersModel.ZipCode);
                cmd.Parameters.AddWithValue("@HomePhoneNumber", providersModel.HomePhoneNumber);
                cmd.Parameters.AddWithValue("@WorkPhoneNumber", providersModel.WorkPhoneNumber);
                cmd.Parameters.AddWithValue("@OtherPhoneNumber", providersModel.OtherPhoneNumber);
                cmd.Parameters.AddWithValue("@FaxNumber", providersModel.FaxNumber);
                cmd.Parameters.AddWithValue("@EmailId", providersModel.EmailId);
                cmd.Parameters.AddWithValue("@Note", providersModel.Note);
                con.OpenConnection();
                result = cmd.ExecuteNonQuery().ToString();

                if (result != null)
                {
                    return result;
                }

                else
                {
                    return null;
                }
            }
            catch
            {
                return result = "";
            }

        }

        public List<ProvidersModel> GetProviders()
        {
            List<ProvidersModel> providerslist = new List<ProvidersModel>();
            con = new DbConnection();
            cmd = new SqlCommand("Sp_Providers", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Flag_Id", "GetAll");
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.OpenConnection();
            sd.Fill(dt);
            con.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                providerslist.Add(
                    new ProvidersModel
                    {
                        PK_Provider = Convert.ToInt32(dr["PK_Provider"]),
                        CompanyId = Convert.ToInt32(dr["CompanyId"]),
                        GroupName = Convert.ToString(dr["GroupName"]),
                        GroupTaxId = Convert.ToString(dr["GroupTaxId"]),
                        GroupNPI = Convert.ToString(dr["GroupNPI"]),
                        ProvCode = Convert.ToString(dr["ProvCode"]),
                        ProvName = Convert.ToString(dr["ProvName"]),
                        Title = Convert.ToString(dr["Title"]),
                        NPI = Convert.ToString(dr["NPI"]),
                        //DOB = Convert.ToDateTime(dr["DOB"]),
                        SSN = Convert.ToString(dr["SSN"]),
                        Speciality = Convert.ToString(dr["Speciality"]),
                        AddressLine1 = Convert.ToString(dr["AddressLine1"]),
                        AddressLine2 = Convert.ToString(dr["AddressLine2"]),
                        City = Convert.ToString(dr["City"]),
                        State = Convert.ToString(dr["State"]),
                        ZipCode = Convert.ToString(dr["ZipCode"]),
                        HomePhoneNumber = Convert.ToString(dr["HomePhoneNumber"]),
                        WorkPhoneNumber = Convert.ToString(dr["WorkPhoneNumber"]),
                        OtherPhoneNumber = Convert.ToString(dr["OtherPhoneNumber"]),
                        FaxNumber = Convert.ToString(dr["FaxNumber"]),
                        EmailId = Convert.ToString(dr["EmailId"]),
                        Note = Convert.ToString(dr["Note"])
                    });
            }

            return providerslist;


        }


        public bool UpdateProviders(ProvidersModel providersModel)
        {
            con = new DbConnection();
            cmd = new SqlCommand("Sp_Providers", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Flag_Id", "Update");
            cmd.Parameters.AddWithValue("@PK_Provider", providersModel.PK_Provider);
            cmd.Parameters.AddWithValue("@CompanyId", providersModel.CompanyId);
            cmd.Parameters.AddWithValue("@GroupName", providersModel.GroupName);
            cmd.Parameters.AddWithValue("@GroupTaxId", providersModel.GroupTaxId);
            cmd.Parameters.AddWithValue("@GroupNPI", providersModel.GroupNPI);
            cmd.Parameters.AddWithValue("@ProvCode", providersModel.ProvCode);
            cmd.Parameters.AddWithValue("@ProvName", providersModel.ProvName);
            cmd.Parameters.AddWithValue("@Title", providersModel.Title);
            cmd.Parameters.AddWithValue("@NPI", providersModel.NPI);
            //cmd.Parameters.AddWithValue("@DOB", providersModel.DOB);
            cmd.Parameters.AddWithValue("@SSN", providersModel.SSN);
            cmd.Parameters.AddWithValue("@Speciality", providersModel.Speciality);
            cmd.Parameters.AddWithValue("@AddressLine1", providersModel.AddressLine1);
            cmd.Parameters.AddWithValue("@AddressLine2", providersModel.AddressLine2);
            cmd.Parameters.AddWithValue("@City", providersModel.City);
            cmd.Parameters.AddWithValue("@State", providersModel.State);
            cmd.Parameters.AddWithValue("@ZipCode", providersModel.ZipCode);
            cmd.Parameters.AddWithValue("@HomePhoneNumber", providersModel.HomePhoneNumber);
            cmd.Parameters.AddWithValue("@WorkPhoneNumber", providersModel.WorkPhoneNumber);
            cmd.Parameters.AddWithValue("@OtherPhoneNumber", providersModel.OtherPhoneNumber);
            cmd.Parameters.AddWithValue("@FaxNumber", providersModel.FaxNumber);
            cmd.Parameters.AddWithValue("@EmailId", providersModel.EmailId);
            cmd.Parameters.AddWithValue("@Note", providersModel.Note);
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






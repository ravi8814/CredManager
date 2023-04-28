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

    public class LoginRepository : ILogin
    {
        DbConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        bool status;
        string query;

        public bool ValidateUser(UserInfoesModel userInfo)
        {
            con = new DbConnection();
            cmd = new SqlCommand("UserLogin", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UserName", userInfo.loginName));
            cmd.Parameters.Add(new SqlParameter("@Password", userInfo.loginPwd));
            con.OpenConnection();
            int User = (int)cmd.ExecuteScalar();
            con.CloseConnection();
            if (User > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}

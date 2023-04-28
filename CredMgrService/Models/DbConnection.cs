using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace CredMgrService.Models
{
    public class DbConnection
    {
        #region 
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        String _error;
        #endregion
        #region
        string str = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        public DbConnection()
        {
            try
            {

                con = new SqlConnection(str);
                con.Open();
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region"Methods"
        public bool OpenConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand();
                cmd.Connection = con;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public SqlConnection GetConnection
        {
            get { return this.con; }
        }

        public bool DisposeConnection()
        {
            con.Dispose();
            return true;
        }

        public bool isDatabaseCanBeConnected()
        {
            if (OpenConnection())
                return true;
            else
                return false;

        }

        public int executeSql(string sqlQuery)
        {
            int intResult = -1;
            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlQuery;
                intResult = cmd.ExecuteNonQuery();
                CloseConnection();
                DisposeConnection();
            }
            catch (Exception ex)
            {
                _error = ex.Message.ToString();
            }
            return intResult;
        }


        public DataTable getDataTable(string sqlQuery)
        {
            DataTable mDT = new DataTable();
            try
            {
                if (con.ConnectionString == "")
                {
                    con.ConnectionString = str;
                }
                adpt = new SqlDataAdapter(sqlQuery, con);
                adpt.Fill(mDT);
            }
            catch (Exception ex)
            {
                _error = ex.Message.ToString();
            }
            return mDT;
        }


        public DataTable getDataRows(string sqlQuery)
        {
            DataTable mDT = new DataTable();
            try
            {
                if (con.ConnectionString == "")
                {
                    con.ConnectionString = str;
                }
                adpt = new SqlDataAdapter(sqlQuery, con);
                adpt.Fill(mDT);
            }
            catch (Exception ex)
            {
                _error = ex.Message.ToString();
            }
            return mDT;
        }

        public DataTable getDataRows(SqlCommand cmd)
        {

            DataTable mDT = new DataTable();
            try
            {
                if (con.ConnectionString == "")
                {
                    con.ConnectionString = str;
                }


                cmd.Connection = con;
                adpt = new SqlDataAdapter(cmd);
                adpt.Fill(mDT);

            }
            catch (Exception ex)
            {
                _error = ex.Message.ToString();
            }
            return mDT;
        }

        public object getParticularData(string sqlQuery)
        {
            object obj = "";
            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlQuery;
                obj = cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                _error = ex.Message.ToString();
            }
            if (obj == null)
                obj = "";
            return obj;
        }

        #endregion

        public string Error
        {
            get { return _error; }
        }

        public static SqlParameter CreateParameter(string Parameter, DbType type, object Value)
        {
            SqlParameter _spm = new SqlParameter();
            _spm.ParameterName = Parameter;
            _spm.DbType = type;
            _spm.Value = Value;
            return _spm;
        }

        public static SqlParameter CreateParameter(string Parameter, DbType type, object Value, ParameterDirection Direction)
        {
            SqlParameter _spm = new SqlParameter();
            _spm.ParameterName = Parameter;
            _spm.DbType = type;
            _spm.Value = Value;
            _spm.Direction = Direction;
            if (type == DbType.String)
            {
                _spm.Size = 3000;
            }
            return _spm;
        }

    }



}
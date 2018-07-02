using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DB
    {
        public static string ConnectionString
        {
            get
            {
                string connString = ConfigurationManager.ConnectionStrings["AWConnection"].ToString();
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connString);
                sb.ApplicationName = ApplicationName ?? sb.ApplicationName;
                sb.ConnectTimeout = (ConnectionTimeOut >0)? ConnectionTimeOut:sb.ConnectTimeout;

                return sb.ToString();
            }
        }

        public static SqlConnection GetsqlConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
        public static int ConnectionTimeOut { get; set; }
        public static string ApplicationName{ get; set; }
    }
}

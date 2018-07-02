using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data.SqlClient;

namespace ASPDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataLayer.DB.ApplicationName = "ASPDemo Application";
                DataLayer.DB.ConnectionTimeOut = 30;
                SqlConnection conn = DataLayer.DB.GetsqlConnection();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
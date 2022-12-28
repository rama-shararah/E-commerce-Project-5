using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectEcommerce
{
    public partial class messagedelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string x = Request.QueryString["UserName"];
            ////string x = "Raghad Alghoul";
            //using (SqlConnection con = new SqlConnection("data source = DESKTOP-KG1IER4\\SQLEXPRESS; database = project5 ; integrated security=SSPI"))
            //{
            //    con.Open();
            //    using (SqlCommand cmd = new SqlCommand($"DELETE FROM contact WHERE Name = @name", con))
            //    {

            //        cmd.CommandType = CommandType.Text;
            //        cmd.Parameters.AddWithValue("@name", x);
            //        int rowsAffected = cmd.ExecuteNonQuery();
            //    }
            //    con.Close();
            //}
            //Response.Redirect("Sallers-page.aspx");
            string id2 = Request.QueryString["UserName"];
            using (SqlConnection con = new SqlConnection("data source = DESKTOP-KG1IER4\\SQLEXPRESS; database = project5 ; integrated security=SSPI"))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM contact WHERE Name= @id", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", id2);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    Response.Redirect("Sallers-page.aspx");

                }
                catch (SqlException aa)
                {
                    Response.Write(aa.ToString());
                }
            }
        }
    }
}
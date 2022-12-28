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
    public partial class removeCarts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id2 = Request.QueryString["Pid"];
            string idd = Request.QueryString["customer_id"];

            using (SqlConnection con = new SqlConnection("data source = DESKTOP-KG1IER4\\SQLEXPRESS; database = project5 ; integrated security=SSPI"))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM test WHERE product_ID=@id;", con))
                    {

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", id2);
                        //cmd.Parameters.AddWithValue("@cc", idd);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    Response.Redirect("cart.aspx");

                }
                catch (SqlException aa)
                {
                    Response.Write(aa.ToString());
                }
            }
        }
    }
}
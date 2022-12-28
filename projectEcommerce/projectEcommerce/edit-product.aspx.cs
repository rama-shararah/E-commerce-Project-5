﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectEcommerce
{

    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string id = Request.QueryString["productId"];
                    SqlConnection connection = new SqlConnection("data source = DESKTOP-KG1IER4\\SQLEXPRESS; database = project5 ; integrated security=SSPI");
                    SqlCommand command = new SqlCommand($"select * from Product WHERE product_ID = '{id}'", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    string folderPath1 = Server.MapPath("~/Image/");
                    while (reader.Read())
                    {
                        product_id.Text = reader[1].ToString();
                        product_categorie.Text = reader[2].ToString();
                        product_description.Value = reader[3].ToString();
                        product_weight.Text = reader[4].ToString();
                        available_quantity.Text = reader[5].ToString();
                        Image1.ImageUrl = $"Image/{reader[6]}";




                    }
                    connection.Close();
                }
                catch (SqlException x) { Response.Write(x.Message); }
            }

        }

        protected void singlebutton2_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/Image/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (filebutton.HasFile)
            {
                filebutton.SaveAs(folderPath + Path.GetFileName(filebutton.FileName));
                string id2 = Request.QueryString["productId"];
                SqlConnection con = new SqlConnection("data source = DESKTOP-KG1IER4\\SQLEXPRESS; database = project5 ; integrated security=SSPI");
                SqlCommand comm = new SqlCommand($"update Product set Name=@name ,Category_ID = @Category_ID , description = @description , quantity = @quantity , ImageProduct = @ImageProduct  ,price=@price WHERE product_ID = '{id2}'", con);

                con.Open();
                comm.Parameters.AddWithValue("@name", product_id.Text);
                comm.Parameters.AddWithValue("@Category_ID", product_categorie.Text);
                comm.Parameters.AddWithValue("@description", product_description.Value);
                comm.Parameters.AddWithValue("@price", product_weight.Text);
                comm.Parameters.AddWithValue("@quantity", available_quantity.Text);
                comm.Parameters.AddWithValue("@ImageProduct", filebutton.FileName);
                comm.ExecuteNonQuery();
                con.Close();

                Response.Redirect("Product-page.aspx");
            }
            else
            {
                //filebutton.SaveAs(folderPath + Path.GetFileName(filebutton.FileName));
                string id2 = Request.QueryString["productId"];
                SqlConnection con = new SqlConnection("data source = DESKTOP-KG1IER4\\SQLEXPRESS; database = project5 ; integrated security=SSPI");
                SqlCommand comm = new SqlCommand($"update Product set Name=@name ,Category_ID = @Category_ID , description = @description , quantity = @quantity ,price=@price WHERE product_ID = '{id2}'", con);

                con.Open();
                comm.Parameters.AddWithValue("@name", product_id.Text);
                comm.Parameters.AddWithValue("@Category_ID", product_categorie.Text);
                comm.Parameters.AddWithValue("@description", product_description.Value);
                comm.Parameters.AddWithValue("@price", product_weight.Text);
                comm.Parameters.AddWithValue("@quantity", available_quantity.Text);
                //  comm.Parameters.AddWithValue("@ImageProduct", filebutton.FileName);
                comm.ExecuteNonQuery();
                con.Close();

                Response.Redirect("Product-page.aspx");

            }
        }

    }
}
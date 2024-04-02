using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Security.Policy;

namespace ElibraryManagement
{
    public partial class PublisherManagement : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                TextBox1.Style["border-color"] = "red";
                Response.Write("<script>alert('Publisher already exists')</script>");
            }
            else
            {
                addNewPublisher(); 
                TextBox1.Style["border-color"] = "light gray";
            }
            clearForm();
        }
        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                updatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher does not exists')</script>");
            }
            clearForm();
        }
        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher does not exists')</script>");
            }
            clearForm();
        }
        //GO button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                getPublisherName();
            }
            else
            {
                Response.Write("<script>alert('Publisher does not exists')</script>");
            }
        }

        //user defined methods
        //add publisher method
        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name) " +
                    "values(@publisher_id,@publisher_name)", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text);
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Added Successfully')</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        //update publisher
        void updatePublisher()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name='" + TextBox2.Text + "' where publisher_id='" + TextBox1.Text + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Updated Successfully')</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {

            }


        }

        //delet publisher
        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl where publisher_id='" + TextBox1.Text + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Deleted Successfully')</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        //function to check if Publisher already exists
        bool checkPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl where publisher_id='" + TextBox1.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {

                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //function to get publisher name
        void getPublisherName()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl where publisher_id='" + TextBox1.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {

                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                con.Close();

            }
            catch (Exception ex)
            {

            }
        }

        //clear form 
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}
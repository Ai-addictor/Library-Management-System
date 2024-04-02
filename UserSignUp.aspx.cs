using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class UserSignUp : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //sign up button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (memberExists())
            {
                TextBox8.Style["border-color"] = "red";
                Response.Write("<script>alert('ID must be unique')</script>");

            }
            else { 
                userSignUp();
                TextBox8.Style["border-color"] = "light gray";
            }

        }

        //check if member id already exists
        bool memberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id='"+TextBox8.Text+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    
                    return true; 
                }
                else { 
                    
                    return false; 
                }
              
            }
            catch(Exception ex)
            {
                
                return false;
            }
        }

        //user signup method
        void userSignUp()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) " +
                    "values(@full_name,@dob,@contact,@email,@state,@city,@pincode,@address,@member_id,@pass,@account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text);
                cmd.Parameters.AddWithValue("@contact", TextBox3.Text);
                cmd.Parameters.AddWithValue("@email", TextBox4.Text);
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text);
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text);
                cmd.Parameters.AddWithValue("@address", TextBox5.Text);
                cmd.Parameters.AddWithValue("@member_id", TextBox8.Text);
                cmd.Parameters.AddWithValue("@pass", TextBox10.Text);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('success')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }


    }      
    
}
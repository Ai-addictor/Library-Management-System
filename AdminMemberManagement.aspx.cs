using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class AdminMemberManagement : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //GO button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMember();
        }
        //Activate button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            setMemberStatus("Active");
        }
        //pause button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            setMemberStatus("Pending");

        }
        //Deactivate button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            setMemberStatus("Deactive");

        }
        //Delete user button
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteUser();
        }

        //user defined methods
        //get member details method
        void getMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        TextBox2.Text = dr.GetValue(0).ToString();  //Full name
                        TextBox7.Text = dr.GetValue(10).ToString(); //Account status
                        TextBox8.Text = dr.GetValue(1).ToString();  //DOB
                        TextBox3.Text = dr.GetValue(2).ToString();  //Contatc No.
                        TextBox4.Text = dr.GetValue(3).ToString();  //Email ID
                        TextBox9.Text = dr.GetValue(4).ToString();  //State
                        TextBox10.Text = dr.GetValue(5).ToString(); //City
                        TextBox11.Text = dr.GetValue(6).ToString(); //Pincode
                        TextBox6.Text = dr.GetValue(7).ToString();  //Full address

                    }

                }
                else
                {
                    Response.Write("<script>alert('Invalid Member ID')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void setMemberStatus(String status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "'where member_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Status Updated')</script>");

                con.Close();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            
        }

        void deleteUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Member has been deleted')</script>");
                con.Close();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
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
    public partial class AuthorManagement : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //Add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                TextBox1.Style["border-color"] = "red";
                Response.Write("<script>alert('Author already exists')</script>");
            }
            else
            {
                addNewAuthor();
                TextBox1.Style["border-color"] = "light gray";
            }
            clearForm();
        }
        //Update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                updateAuthorName(); 
            }
            else
            {
                Response.Write("<script>alert('Author does not exists')</script>");
            }
            clearForm();
        }
        //Delete Button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not exists')</script>");
            }
            clearForm();
        }
        //Go Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists()) {
                getAuthorName();
            }
            else
            {
                Response.Write("<script>alert('Author does not exists')</script>");
            }
        }

        //user defined functions
        //add author
        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) " +
                    "values(@author_id,@author_name)", con);

                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text);
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text);
                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Added Successfully')</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //updte author name
        void updateAuthorName()
        {
            
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name='" + TextBox2.Text + "' where author_id='"+TextBox1.Text+"'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Author Updated Successfully')</script>");
                    GridView1.DataBind();

            }
            catch ( Exception ex){
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            
            
        }
        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl where author_id='" + TextBox1.Text + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Deleted Successfully')</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {

            }
        }
           
        

        //function to check if author already exists
        bool checkAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl where author_id='" + TextBox1.Text + "'", con);
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

        void getAuthorName()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl where author_id='" + TextBox1.Text + "'", con);
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

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

    }
}
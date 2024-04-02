using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class LMS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["role"] == null){
                    LinkButton1.Visible = true; //user login linkbutton
                    LinkButton2.Visible = true; //signup button

                    LinkButton3.Visible = false; //logout linkbutton
                    LinkButton7.Visible = false; //Hello user linkbutton

                    LinkButton6.Visible = true;
                    LinkButton11.Visible = false; //author management linkbutton
                    LinkButton12.Visible = false; //publisher management linkbutton
                    LinkButton8.Visible = false; //book inventory linkbutton
                    LinkButton9.Visible = false; //book issueing linkbutton
                    LinkButton10.Visible = false; //member management linkbutton
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; //user login linkbutton
                    LinkButton2.Visible = false; //signup button

                    LinkButton3.Visible = true; //logout linkbutton
                    LinkButton7.Visible = true; //Hello user linkbutton
                    LinkButton7.Text = "Hello Admin";

                    LinkButton6.Visible = false;     //admin login linkbutton
                    LinkButton11.Visible = true; //author management linkbutton
                    LinkButton12.Visible = true; //publisher management linkbutton
                    LinkButton8.Visible = true; //book inventory linkbutton
                    LinkButton9.Visible = true; //book issueing linkbutton
                    LinkButton10.Visible = true; //member management linkbutton
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //user login linkbutton
                    LinkButton2.Visible = false; //signup button

                    LinkButton3.Visible = true; //logout linkbutton
                    LinkButton7.Visible = true;  //Hello user linkbutton
                    LinkButton7.Text = "Hello " + Session["username"].ToString();

                    LinkButton6.Visible = true;     //admin login linkbutton
                    LinkButton11.Visible = false; //author management linkbutton
                    LinkButton12.Visible = false; //publisher management linkbutton
                    LinkButton8.Visible = false; //book inventory linkbutton
                    LinkButton9.Visible = false; //book issueing linkbutton
                    LinkButton10.Visible = false; //member management linkbutton
                }
            }
            catch(Exception ex) { }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorManagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookInventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookIssue.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMemberManagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignUp.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }
        //logout Button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["fullname"] = null;
            Session["role"] = null;
            Session["status"] = null;

            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true; // sign up link button

            LinkButton3.Visible = true; // logout link button
            LinkButton7.Visible = false; // hello user link button


            LinkButton6.Visible = true; // admin login link button
            LinkButton11.Visible = false; // author management link button
            LinkButton12.Visible = false; // publisher management link button
            LinkButton8.Visible = false; // book inventory link button
            LinkButton9.Visible = false; // book issuing link button
            LinkButton10.Visible = false; // member management link button

            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");

        }
    }
}
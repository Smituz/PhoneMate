using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace PhoneMate
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString;
            try
            {
                using (con)
                {
                    string usernm = (string)Session["Username"];
                    string command = "Select * from Contacts where UserID = (Select UserID from Users where Username = @username) order by Fullname";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@username", usernm);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    AllContacts.DataSource = rdr;
                    AllContacts.DataBind();
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Errors: " + ex.Message);
            }

        }

        protected void SearchContact_Click(object sender, EventArgs e)
        {
            string query = q.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString;
            try
            {
                using (con)
                {
                    string usernm = (string)Session["Username"];
                    string command = "Select * from Contacts where UserID = (Select UserID from Users where Username = @username ) AND FullName LIKE @query";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@query", "%" + query + "%");
                    cmd.Parameters.AddWithValue("@username", usernm);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        SearchPanel.Visible = true;  // Show the panel when results are found
                        SearchResults.DataSource = rdr;
                        SearchResults.DataBind();
                    }
                    else
                    {
                        SearchPanel.Visible = false;
                        Noresult.Visible = true;

                        // Hide the panel if no results are found
                    }

                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Errors: " + ex.Message);
            }
        }
    }
}

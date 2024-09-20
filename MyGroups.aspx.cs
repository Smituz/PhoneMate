using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneMate
{
    public partial class MyGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadGroups();
            }
        }

        private void LoadGroups()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString;

            try
            {
                using (con)
                {
                    string command = "SELECT GroupName FROM Groups";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    ddlGroups1.DataSource = rdr;
                    ddlGroups1.DataTextField = "GroupName";
                    ddlGroups1.DataValueField = "GroupName"; // Adjust this as per your Group table
                    ddlGroups1.DataBind();

                    // Add a default item
                    ddlGroups1.Items.Insert(0, new ListItem("Select Group", ""));
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Response.Write("Errors: " + ex.Message);
            }
        }

        protected void DDLGrpChng(object sender, EventArgs e)
        {
            string selectedGroup = ddlGroups1.SelectedValue;
            if (!string.IsNullOrEmpty(selectedGroup))
            {
                LoadContacts(selectedGroup);
            }
            else
            {
                gvContacts.Visible = false;
                NoResults.Visible = false;
            }
        }

        private void LoadContacts(string groupName)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString;

            try
            {
                using (con)
                {
                    string usernm = (string)Session["Username"];
                    string command = "SELECT c.FullName, c.PhoneNumber, c.Email " +
                                     "FROM Contacts c " +
                                     "JOIN Users u ON c.UserID = u.UserID " +
                                     "JOIN Groups g ON c.GroupID = g.GroupID " +
                                     "WHERE u.Username = @username AND g.GroupName = @groupName";

                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.Parameters.AddWithValue("@username", usernm);
                    cmd.Parameters.AddWithValue("@groupName", groupName);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        gvContacts.Visible = true;
                        gvContacts.DataSource = rdr;
                        gvContacts.DataBind();
                        NoResults.Visible = false;
                    }
                    else
                    {
                        gvContacts.Visible = false;
                        NoResults.Visible = true;
                    }

                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Response.Write("Errors: " + ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace PhoneMate
{
    public partial class AddContact : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack) // Ensure the groups are only populated once per page load, not on every postback
            {
                PopulateGroups();
            }
        }

        private void PopulateGroups()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString;

            try
            {
                using (con)
                {
                    string command = "SELECT GroupID, GroupName FROM Groups";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    ddlGroup.Items.Clear(); // Clear existing items

                    // Add a default item (optional)
                    ddlGroup.Items.Add(new ListItem("Select a Group", ""));

                    while (rdr.Read())
                    {
                        string groupID = rdr["GroupID"].ToString();
                        string groupName = rdr["GroupName"].ToString();
                        ddlGroup.Items.Add(new ListItem(groupName, groupID));
                    }

                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Errors: " + ex.Message);
            }
        }


        protected void btnAddContact_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) // Check if all validations pass
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = WebConfigurationManager.ConnectionStrings["PhoneMateDBConnection"].ConnectionString;

                try
                {
                    using (con)
                    {
                        string command = "INSERT INTO Contacts (FullName, PhoneNumber, Email, Address, UserID, GroupID) " +
                                         "VALUES (@FullName, @PhoneNumber, @Email, @Address, (SELECT UserID FROM Users WHERE Username = @Username), @GroupID)";
                        SqlCommand cmd = new SqlCommand(command, con);
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Username", (string)Session["Username"]);
                        cmd.Parameters.AddWithValue("@GroupID", ddlGroup.SelectedValue);

                        con.Open();
                        int  i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            // Redirect to home page on successful addition
                            Response.Redirect("Home.aspx");
                        }
                        else
                        {
                            Response.Write("error in saving the contact.");
                        }                      
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Errors: " + ex.Message);
                }
            }
        }
    }
}
